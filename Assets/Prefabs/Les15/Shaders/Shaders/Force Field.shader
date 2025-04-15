// Определение шейдера с именем "Ultimate 10+ Shaders/ForceField"
Shader "Ultimate 10+ Shaders/ForceField" 
{
    // Секция свойств, доступных в инспекторе Unity
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}  // Основная текстура
        [HDR] _Color ("Color", Color) = (1,1,1,1)  // Цвет с HDR-эффектом
        
        _FresnelPower("Fresnel Power", Range(0, 10)) = 3  // Сила эффекта Френеля
        _ScrollDirection ("Scroll Direction", Vector) = (0, 0, 0, 0)  // Направление скролла текстуры
    }

    SubShader
    {
        // Теги рендеринга - прозрачный объект
        Tags { 
            "RenderType"="Transparent" 
            "IgnoreProjector"="True" 
            "Queue"="Transparent" 
        }
        
        // Настройки смешивания для прозрачности
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100  // Уровень детализации
        Cull Back  // Отсечение задних граней
        Lighting Off  // Отключение стандартного освещения
        ZWrite On  // Включение записи в буфер глубины

        Pass
        {
            CGPROGRAM
            // Объявление вершинного и фрагментного шейдеров
            #pragma vertex vert
            #pragma fragment frag
            
            // Подключение стандартных функций Unity
            #include "UnityCG.cginc"

            // Настройки целевой версии шейдера
            #ifndef SHADER_API_D3D11
                #pragma target 3.0
            #else
                #pragma target 4.0
            #endif

            // Входные данные вершинного шейдера
            struct appdata
            {
                float4 vertex : POSITION;  // Позиция вершины
                float2 uv : TEXCOORD0;    // UV-координаты
                float3 normal : NORMAL;   // Нормаль
            };

            // Данные, передаваемые из вершинного в фрагментный шейдер
            struct v2f
            {
                float2 uv : TEXCOORD0;    // UV-координаты
                float rim : TEXCOORD1;    // Коэффициент Френеля
                float4 position : SV_POSITION;  // Позиция на экране
            };

            // Объявление переменных
            sampler2D _MainTex;           // Текстура
            float4 _MainTex_ST;           // Параметры трансформации текстуры
            
            fixed4 _Color;                // Цвет
            half _FresnelPower;           // Сила эффекта Френеля
            half4 _ScrollDirection;       // Направление скролла (исправлено на half4)

            // Вершинный шейдер
            v2f vert (appdata v)
            {
                v2f o;
                
                // Преобразование позиции в экранные координаты
                o.position = UnityObjectToClipPos(v.vertex);
                
                // Применение трансформации к UV-координатам
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                // Вычисление направления взгляда и эффекта Френеля (исправленная версия)
                float3 viewDir = normalize(ObjSpaceViewDir(v.vertex)); // Объявлено локально
                o.rim = 1.0 - saturate(dot(viewDir, v.normal));
                
                // Анимирование UV-координат
                o.uv += _ScrollDirection.xy * _Time.y; // Используем только xy компоненты
                
                return o;
            }

            // Фрагментный шейдер
            fixed4 frag (v2f i) : SV_Target
            {
                // Чтение текстуры с учетом цвета и эффекта Френеля
                fixed4 pixel = tex2D(_MainTex, i.uv) * _Color * pow(i.rim, _FresnelPower); // Исправлено pow
                
                // Плавное появление эффекта по краям
                pixel = lerp(fixed4(0,0,0,0), pixel, i.rim);
                
                // Ограничение значений цвета
                return clamp(pixel, 0, _Color);
            }
            ENDCG
        }
    }
    
    // Фолбэк шейдер (используется, если основной не поддерживается)
    FallBack "Diffuse"
}