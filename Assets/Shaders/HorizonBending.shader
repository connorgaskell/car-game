Shader "Custom/HorizonBending" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            uniform float3 _BendAmount;
            uniform float3 _BendOrigin;
            uniform float _BendFalloff;

            float4 bendVertices(float4 v) {
                _BendAmount *= 0.0001f;
 
                float4 world = mul(unity_ObjectToWorld, v);
                float dist = length(world.xyz - _BendOrigin.xyz);
                dist = max(0, dist - _BendFalloff);

                dist = pow(dist, 2.0f);
                world.xyz += dist * _BendAmount;
                return mul(unity_WorldToObject, world);
            }

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(bendVertices(v.vertex));
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
