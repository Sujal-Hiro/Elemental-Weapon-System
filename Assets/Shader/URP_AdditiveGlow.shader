Shader "Custom/URP_AdditiveGlow"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _TilingOffset ("Tiling and Offset", VECTOR) = (1, 1, 0, 0)
        _GlowIntensity ("Glow Intensity", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }

            Blend One One
            ZWrite Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #pragma multi_compile_instancing

            // Properties
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;
            float _GlowIntensity;

            // Structs
            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS);

                // Apply tiling and offset to the UVs
                OUT.uv = IN.uv * _MainTex_ST.xy + _MainTex_ST.zw;
                OUT.color = float4(1, 1, 1, 1);

                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Sample the main texture with tiling and offset
                half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                
                // Apply glow intensity to the texture color
                half3 emissive = texColor.rgb * _GlowIntensity;
                half4 finalColor = half4(emissive, texColor.a);

                return finalColor;
            }

            ENDHLSL
        }
    }

    FallBack "Diffuse"
}
