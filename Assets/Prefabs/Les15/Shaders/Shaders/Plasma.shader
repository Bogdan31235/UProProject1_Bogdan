Shader "Ultimate 10+ Shaders/Plasma"
{
    Properties
    {
        [HDR] _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Normal("Normal map", 2D) = "bump" {}

        _NoiseTex ("Noise", 2D) = "white" {}
        _MovementDirection ("Movement Direction", float) = (0, -1, 0, 1)
        
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
    }
    SubShader
    {
        Tags{ "RenderType"="Transparent" "Queue"="Transparent"}
		Blend SrcAlpha OneMinusSrcAlpha
        LOD 100
        Cull [_Cull]
        Lighting Off
        ZWrite On
        
        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows alpha

        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _Normal;
        sampler2D _NoiseTex;

        half2 _MovementDirection;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_Normal;
            float2 uv_NoiseTex;
        };

        fixed4 _Color;


        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        fixed4 pixel, alphaPixel;
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            IN.uv_NoiseTex += _MovementDirection * _Time.y / 2.0;
            IN.uv_MainTex += _MovementDirection * _Time.y;
            IN.uv_Normal += _MovementDirection * _Time.y / 2.0;

            alphaPixel = tex2D (_NoiseTex, IN.uv_NoiseTex);
            
            pixel = tex2D (_MainTex, IN.uv_MainTex) * _Color * alphaPixel.r;
            o.Albedo = pixel.rgb;

            o.Normal = tex2D(_Normal, IN.uv_Normal);
            
            o.Alpha = alphaPixel.r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
