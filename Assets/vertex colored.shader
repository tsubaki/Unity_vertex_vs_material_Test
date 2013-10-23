Shader "User/Vertex Colored" {
	Properties {
	    _MainTex ("Base (RGB)", 2D) = "white" {}
	}
 
	SubShader {
	    Pass {
	        ColorMaterial Emission
	        Lighting OFF
	        SetTexture [_MainTex] {
	            Combine texture * primary, texture * primary
	        }
	    }
	}
 
	Fallback " VertexLit", 1
}