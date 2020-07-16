Shader "Volumetric/SphereMarching"
{
    Properties
    {
        _Sphere ("Sphere ray", Float) = 0.1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
          

            #include "UnityCG.cginc"

            float _Sphere;
            float _Threshold;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float3 wPos : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            float sphere(float3 p, float r) //radius
            {
                return length(p) - _Sphere;  
            }


            float box(float3 p, float3 b) //box dimension
            {
                float3 d = abs(p) - b;
                return length(max(d, 0.0)) + min(max(d.x,max(d.y,d.z)),0.0);
            }

            float torus(float3 p, float2 t) // (size of the torus, thickness)
            {
                float2 q = float2(length(p.xz)-t.x,p.y);
                return length(q) - t.y;
            }


            float map(float3 p)
            {
            return  min(sphere(p,_Sphere),torus(p, float2(0.40,0.01))) ;
            }

            float RaymarchHit(float3 origin, float3 ray)
            {
                 float t = 0.0;
                for (int i = 0; i < 32; i++)
                {
                    float3 p = origin + ray * t;
                    float d = map(p);
                    if(d < 0.01)
                        return t;
                    t += d*0.5;
                }
                return t;
            }


            fixed4 frag (v2f i) : SV_Target
            {
               float3 viewDirection = normalize(i.wPos - _WorldSpaceCameraPos);
               float t = RaymarchHit(i.wPos, viewDirection);

               float fog = 1.0 / (1.0 + t * t * 0.1);
               fixed4 col = fixed4(fog,fog,fog,fog);
               return col;
 
            }
            ENDCG
        }
    }
}
