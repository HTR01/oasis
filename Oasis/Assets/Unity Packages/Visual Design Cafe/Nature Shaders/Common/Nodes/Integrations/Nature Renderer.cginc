// Copyright 2020 Visual Design Cafe. All rights reserved.
// Package: Nature Shaders
// Website: https://www.visualdesigncafe.com/nature-shaders
// Documentation: https://support.visualdesigncafe.com/hc/categories/900000043503

#ifndef NODE_INSTANCED_INCLUDED
#define NODE_INSTANCED_INCLUDED

#ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED

uniform StructuredBuffer<float4x4> _NatureRendererBuffer;

float4x4 inverse(float4x4 input)
 {
     #define minor(a,b,c) determinant(float3x3(input.a, input.b, input.c))
     
     float4x4 cofactors = float4x4(
          minor(_22_23_24, _32_33_34, _42_43_44), 
         -minor(_21_23_24, _31_33_34, _41_43_44),
          minor(_21_22_24, _31_32_34, _41_42_44),
         -minor(_21_22_23, _31_32_33, _41_42_43),
         
         -minor(_12_13_14, _32_33_34, _42_43_44),
          minor(_11_13_14, _31_33_34, _41_43_44),
         -minor(_11_12_14, _31_32_34, _41_42_44),
          minor(_11_12_13, _31_32_33, _41_42_43),
         
          minor(_12_13_14, _22_23_24, _42_43_44),
         -minor(_11_13_14, _21_23_24, _41_43_44),
          minor(_11_12_14, _21_22_24, _41_42_44),
         -minor(_11_12_13, _21_22_23, _41_42_43),
         
         -minor(_12_13_14, _22_23_24, _32_33_34),
          minor(_11_13_14, _21_23_24, _31_33_34),
         -minor(_11_12_14, _21_22_24, _31_32_34),
          minor(_11_12_13, _21_22_23, _31_32_33)
     );
     #undef minor
     return transpose(cofactors) / determinant(input);
 }
#endif

void SetupNatureRenderer()
{
    #ifdef UNITY_PROCEDURAL_INSTANCING_ENABLED
        #define unity_ObjectToWorld unity_ObjectToWorld
        #define unity_WorldToObject unity_WorldToObject

        unity_ObjectToWorld = _NatureRendererBuffer[unity_InstanceID];
        unity_WorldToObject = inverse(unity_ObjectToWorld);
    #endif
}

void Instanced_float( float3 vertex, out float3 vertexOut )
{
    vertexOut = vertex;
}
#endif