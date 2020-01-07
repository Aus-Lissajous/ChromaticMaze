Shader "Hidden/BinaryImager"
{
    Properties
    {
        _MainTex("-", 2D) = "" {}
        _DitherTex("-", 2D) = "" {}
        _Color0("-", Color) = (0, 0, 0, 1)
        _Color1("-", Color) = (1, 1, 1, 1)
    }
    CGINCLUDE

    #include "UnityCG.cginc"

    #pragma multi_compile _ BLEND_MIDPOINT

    sampler2D _MainTex;
    float2 _MainTex_TexelSize;

    sampler2D _DitherTex;
    float2 _DitherTex_TexelSize;

    float _DitherScale;
    half4 _Color0;
    half4 _Color1;
    half _BlendFactor;

    half4 frag(v2f_img i) : SV_Target 
    {
        float2 dither_uv = i.uv * _DitherTex_TexelSize;
        dither_uv /= _MainTex_TexelSize * _DitherScale;

        float dither = tex2D(_DitherTex, dither_uv).a;
        half4 source = tex2D(_MainTex, i.uv);

        half bw = dot(source.rgb, (half3)0.33333333);

    #if BLEND_MIDPOINT
        half p_bw = lerp(bw, bw > dither, max(_BlendFactor * 2 - 1, 0));
        half p_bl = min(_BlendFactor * 2, 1);
    #else
        half p_bw = bw > dither;
        half p_bl = _BlendFactor;
    #endif

        half3 out_rgb = lerp(source.rgb, lerp(_Color0, _Color1, p_bw), p_bl);
        return half4(out_rgb, source.a);
    }

    ENDCG
    SubShader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            ENDCG
        }
    }
}
