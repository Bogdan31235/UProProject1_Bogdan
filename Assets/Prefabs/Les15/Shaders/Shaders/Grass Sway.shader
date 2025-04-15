Shader "Ultimate 10+ Shaders/Grass Sway"
{
    Properties
    {
        // Основные свойства материала
        _Color ("Color", Color) = (1,1,1,1)  // Основной цвет
        _MainTex ("Albedo (RGB)", 2D) = "white" {}  // Текстура альбедо
        _Normal ("Normal Map", 2D) = "bump" {}  // Карта нормалей
        _NormalStrength ("Normal Strength", float) = 0.25  // Сила нормалей

        // Физические свойства материала
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5  // Гладкость
        _Metallic ("Metallic", Range(0, 1)) = 0.5  // Металличность

        // Настройки травы
        _Cutoff ("Cutoff", Range(0, 1)) = 0.25  // Порог прозрачности
        _Speed ("Speed", float) = 0.25  // Скорость колыхания
        _WindDirection ("Wind Direction", float) = (1,0,0,1)  // Направление ветра
        
        // Настройки рендеринга
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0  // Режим отсечения граней
    }

    SubShader
    {   
        Tags { "RenderType"="Cutout" }  // Тип рендеринга - с вырезанием
        LOD 200  // Уровень детализации
        Cull [_Cull]  // Применение выбранного режима отсечения

        CGPROGRAM
        // Директивы компилятора
        #pragma surface surf Standard keepalpha fullforwardshadows addshadow  // Использование стандартной модели освещения
        #pragma vertex vert  // Указание вершинного шейдера

        // Настройки целевой версии шейдера
        #ifndef SHADER_API_D3D11
            #pragma target 3.0
        #else
            #pragma target 4.0
        #endif

        // Объявление переменных
        fixed4 _Color;
        sampler2D _MainTex;
        sampler2D _Normal;
        half _NormalStrength;
        half _Smoothness;
        half _Metallic;
        half _Cutoff;
        half _Speed;
        half4 _WindDirection;
        
        // Входные данные для фрагментного шейдера
        struct Input
        {
            float2 uv_MainTex;  // UV-координаты для основной текстуры
            float2 uv_Normal;   // UV-координаты для карты нормалей
        };

        // Функция поверхности (фрагментный шейдер)
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Чтение текстуры и применение цвета
            fixed4 pixel = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = pixel.rgb;  // Основной цвет
            
            // Вырезание по альфа-каналу
            clip(pixel.a - _Cutoff);
            o.Alpha = pixel.a - _Cutoff;

            // Физические свойства
            o.Smoothness = _Smoothness;
            o.Metallic = _Metallic;
            
            // Применение карты нормалей
            o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Normal)) * _NormalStrength;
        }
            
        // Структура входных данных вершинного шейдера
        struct appdata {
            float4 vertex : POSITION;  // Позиция вершины
            float4 tangent : TANGENT;  // Касательный вектор
            float3 normal : NORMAL;    // Нормаль
            float4 texcoord : TEXCOORD0;  // UV-координаты
            float4 texcoord1 : TEXCOORD1;  // Вторичные UV-координаты
            fixed4 color : COLOR;      // Цвет вершины
            UNITY_VERTEX_INPUT_INSTANCE_ID  // ID для GPU Instancing
        };

        // Вершинный шейдер (анимация колыхания травы)
        void vert(inout appdata v)
        {
            // Анимация ветра:
            // 1. Преобразуем позицию вершины в мировые координаты
            // 2. Используем Y-компоненту для эффекта "раскачивания"
            // 3. Применяем направление ветра и синусоидальную функцию для плавности
            v.vertex.xyz += UnityObjectToWorldDir(v.vertex).y * _WindDirection * sin(_Time.y * _Speed);
        }
        ENDCG
    }
    FallBack "Diffuse"  // Резервный шейдер
}