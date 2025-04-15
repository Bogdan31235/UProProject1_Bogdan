Shader "Ultimate 10+ Shaders/Outline"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", Range(0, 4)) = 0.25
        
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Geometry" "Queue"="Transparent" }
        LOD 200
        Cull [_Cull]

        Pass{
            ZWrite Off
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            struct appdata {
                float4 vertex : POSITION;
                float4 tangent : TANGENT;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f{
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
            };

            fixed4 _OutlineColor;
            half _OutlineWidth;

            v2f vert(appdata input){
                input.vertex += float4(input.normal * _OutlineWidth, 1);

                v2f output;

                output.pos = UnityObjectToClipPos(input.vertex);
                output.normal = mul(unity_ObjectToWorld, input.normal);

                return output;
            }

            fixed4 frag(v2f input) : SV_Target
            {
                return _OutlineColor;
            }

            ENDCG
        }

        ZWrite On
        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows

        #ifndef SHADER_API_D3D11
            #pragma target 3.0
        #else
            #pragma target 4.0
        #endif

        UNITY_INSTANCING_BUFFER_START(Props)

        UNITY_INSTANCING_BUFFER_END(Props)

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;
        sampler2D _MainTex;

        fixed4 pixel;
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            pixel = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = pixel.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
