#version 100

uniform mat4 modelViewMatrix;
uniform mat4 projectionMatrix;
attribute vec3 vsiPosition;
attribute vec3 vsiNormal;
attribute vec2 vsiTexCoord;
 
varying vec2 vsoTexCoord;
varying vec3 vsoNormal;
varying vec4 vsoModPosition;
varying vec4 vsoPosition;

void main(void) {

  vsoNormal = (transpose(inverse(modelViewMatrix)) * vec4(vsiNormal.xyz, 0.0)).xyz;
  vsoModPosition = modelViewMatrix * vec4(vsiPosition.xyz, 1.0);
  vsoPosition = vec4(vsiPosition.xyz, 1.0);
  gl_Position = projectionMatrix * modelViewMatrix * vec4(vsiPosition.xyz, 1.0);
  vsoTexCoord = vsiTexCoord;
  //gl_FogFragCoord = gl_Position.z;
}
