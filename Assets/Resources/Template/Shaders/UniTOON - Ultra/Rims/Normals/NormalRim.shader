﻿// Shader created by N1warhead
// www.warhead-designz.com


Shader "UniToonUltra/Rim/NormalOutline" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
	    _RimColor ("Rim Color", Color) = (0.8,0.8,0.8,0.6)
        _RimPower ("Rim Power", Float) = 1.4
        _ShadowColor ("Shadow", Color) = (0.0,0.0,0.0,1)
		_HighColor ("Highlighting Color", Color) = (0.5,0.5,0.5,1) 
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Texture", 2D) = "white" {}
		_Ramp ("Shading Ramp", 2D) = "gray" {}
		_BumpMap ("Normalmap", 2D) = "bump" {}
    }
 
     SubShader {
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Ramp
 
		sampler2D _Ramp;
		float4 _HighColor;
		float4 _ShadowColor;
		float _RimPower;
		float4 _RimColor;
        
		half4 LightingRamp (SurfaceOutput s, half3 lightDir, half atten) {
		
            half NdotL = dot (s.Normal, lightDir);
			half diff = NdotL * 0.5 + 0.5;
			half3 ramp = tex2D (_Ramp, float2(diff, diff)).rgb;
			ramp = lerp(_ShadowColor,_HighColor,ramp);
			half4 c;
			c.rgb = (s.Albedo * _LightColor0.rgb * diff * ramp) * (atten * 2);
			c.a = s.Alpha;
			return c;
		}
 
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
		};
		sampler2D _MainTex;
		sampler2D _BumpMap;
		fixed4 _Color;
 
		void surf (Input IN, inout SurfaceOutput o) {
		
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Color;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			half rim = 1.0f - saturate( dot(normalize(IN.viewDir), o.Normal) );
			o.Emission = (_RimColor.rgb * pow(rim, _RimPower)) * _RimColor.a;
		}
 
		ENDCG
 
		CGINCLUDE
		#include "UnityCG.cginc"
 
		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};
 
		struct v2f {
			float4 pos : POSITION;
			float4 color : COLOR;
		};
 
		uniform float _Outline;
		uniform float4 _OutlineColor;
 
		v2f vert(appdata v) {
			v2f o;
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
 
			float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
			float2 offset = TransformViewToProjection(norm.xy);
 
			o.pos.xy += offset * o.pos.z * _Outline;
			o.color = _OutlineColor;
			return o;
		}
		ENDCG
 
		Pass {
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
 
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			half4 frag(v2f i) :COLOR { return i.color; }
			ENDCG
		}
 
    }
 
	Fallback "Diffuse"
}