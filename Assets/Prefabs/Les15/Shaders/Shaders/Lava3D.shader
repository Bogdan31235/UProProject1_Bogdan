Shader "Ultimate 10+ Shaders/Lava3D"
{
    Properties
    {
        [HDR] _Color ("Color", Color) = (1,1,1,1) // HDR-цвет для яркого свечения
        _MainTex ("Albedo (RGB)", 2D) = "white" {} // Основная текстурная карта
        _HeightMap ("Height Map (Black and White)", 2D) = "bump" {} // Карта высот (черно-белая)
        _FlowDirection ("Flow Direction", Vector) = (1, 0, 0, 0) // Направление течения лавы
        _Speed ("Speed", float) = 0.25 // Скорость анимации
        _Amplitude ("Amplitude", float) = 1.0 // Амплитуда волн

        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2 // Режим отсечения (Back по умолчанию)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" } // Непрозрачный рендеринг
        LOD 150 // Уровень детализации
        Cull [_Cull] // Применение выбранного режима отсечения

        CGPROGRAM
        // Директивы компилятора:
        #pragma surface surf Standard addshadow fullforwardshadows // Стандартная модель освещения с тенями
        #pragma vertex vert // Использование кастомного вершинного шейдера

        // Настройки совместимости:
        #ifndef SHADER_API_D3D11
            #pragma target 3.0
        #else
            #pragma target 4.0
        #endif

        // Объявление переменных:
        fixed4 _Color; // Основной цвет
        sampler2D _MainTex; // Сэмплер основной текстуры
        sampler2D _HeightMap; // Сэмплер карты высот
        half4 _FlowDirection; // Направление течения (x,y,z) + резерв (w)
        half _Speed; // Скорость анимации
        half _Amplitude; // Интенсивность волн

        // Входные данные для фрагментного шейдера:
        struct Input
        {
            float2 uv_MainTex; // UV-координаты основной текстуры
            float2 uv_HeightMap; // UV-координаты карты высот
        };

        // Фрагментный шейдер (поверхность):
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Анимируем UV-координаты с учетом времени и направления:
            float2 flowUV = IN.uv_MainTex + _FlowDirection.xy * fmod(_Time.y, 1200) * _Speed;
            
            // Читаем текстуру и применяем цвет:
            fixed4 pixel = tex2D(_MainTex, flowUV) * _Color;
            o.Albedo = pixel.rgb; // Устанавливаем цвет поверхности
        }

        // Структура данных вершинного шейдера:
        struct appdata {
            float4 vertex : POSITION; // Позиция вершины
            float4 tangent : TANGENT; // Касательный вектор
            float3 normal : NORMAL; // Нормаль
            float4 texcoord : TEXCOORD0; // Основные UV
            float4 texcoord1 : TEXCOORD1; // Дополнительные UV (используются для карты высот)
            fixed4 color : COLOR; // Цвет вершины
            UNITY_VERTEX_INPUT_INSTANCE_ID // Поддержка GPU Instancing
        };

        // Вершинный шейдер:
        void vert(inout appdata v)
        {
            // Анимируем UV для карты высот:
            float4 heightUV = v.texcoord1 + _FlowDirection * fmod(_Time.y, 1200) * _Speed;
            
            // Читаем карту высот:
            fixed4 texPixel = tex2Dlod(_HeightMap, heightUV);
            
            // Модифицируем Y-координату вершины:
            v.vertex.y += texPixel.r * _Amplitude; // Используем красный канал для высоты
        }
        ENDCG
    }
    FallBack "Diffuse" // Резервный шейдер
}