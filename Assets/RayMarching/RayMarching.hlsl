#ifndef MYHLSLINCLUDE_INCLUDED
#define MYHLSLINCLUDE_INCLUDED
			float EPSILON = 0.001;
			float _SphereSize = 0.3;
            float sphere(float3 p, float r) //radius
            {
                return length(p) - 0.2;  
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
			
			float displacement(float3 p, float time)
			{
			return sin(20*p.x+time)*sin(20*p.y+time)*sin(20*p.z+time); 
			}
			
			float opDisplace(  float3 p, float time )
			{
				float d2 = displacement(p, time);
				return d2;
			}


            float map(float3 p, float3 _Position, float time)
            {
            p = p - _Position.xyz;
			
			float s = sphere(p,_SphereSize);
            float disp = opDisplace(p,time);
			return s+disp*0.03+max(0.8,disp)*0.1;
            }

            void RaymarchHit_float(float3 origin, float3 ray, float3 _Position,float time, out float t)
            {
                 t = 0.0;
                for (int i = 0; i < 32; i++)
                {
                    float3 p = origin + ray * t;
                    float d = map(p, _Position, time);
                    if(d < 0.01)
                        break;
                    t += d*0.5;
                }
                
            }

		/*	void EstimateNormal_float(float3 origin, float3 _Position, out float3 normal, float time)
			{
				normal = normalize(float3(
					map(float3(origin.x + 0.01, origin.y, origin.z), _Position) - map(float3(origin.x - 0.01, origin.y, origin.z),_Position),
					map(float3(origin.x, origin.y + 0.01, origin.z),_Position) - map(float3(origin.x, origin.y - 0.01, origin.z),_Position),
					map(float3(origin.x, origin.y, origin.z  + 0.01),_Position) - map(float3(origin.x, origin.y, origin.z - 0.01),_Position)
				));
			}*/
			
#endif