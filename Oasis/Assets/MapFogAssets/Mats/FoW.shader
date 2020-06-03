Shader "Hidden/FoW"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _SecondaryTex ("Second Texture", 2D) = "white" {}
    }
    SubShader
    {

		Tags
		{
		"Queue" = "Transparent+1"
		}
        Pass
        {
			Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _SecondaryTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) + tex2D(_SecondaryTex, i.uv);
				if ((col.g == 1 && col.r == 0 && col.b == 0) || (col.r == 1 && col.b == 0 && col.g == 0) || (col.r == 1 && col.b == 1 && col.g == 0))
				{
					col.a = 0.0f;
				}
				else {
					col.a = 1;
				}
                //return fixed4(0,0,0,col.a);
				return col;
            }
            ENDCG
        }
    }
}
