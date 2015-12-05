#version 100

uniform sampler2D myTexture[5];
uniform vec4 lumpos;

varying vec2 vsoTexCoord;
varying vec3 vsoNormal;
varying vec4 vsoModPosition;
varying vec4 vsoPosition;

mediump vec4 gl_FragColor;

void main(void) {

  float scale = vsoPosition.y;

  vec3 lum = normalize(vsoModPosition.xyz - lumpos.xyz);
  float intensity = dot(normalize(vsoNormal),-lum);
  float factor = 0.1;
  float factorN = 0.2;
  if( intensity > 0.1  && intensity <= 0.3) factor = 1.0;
  else if ( intensity > 0.3 && intensity <= 0.5) factor = 0.8;
  else if ( intensity > 0.5 && intensity <= 0.7) factor = 0.6;
  else if ( intensity > 0.7 && intensity <= 0.9) factor = 0.4;
  else factor = 0.2;
  
  if(scale > -10.0 && scale <= 5.0){
  gl_FragColor = texture2D(myTexture[0], vsoTexCoord);
  gl_FragColor *= vec4(factor, factor, factor, 0.5);
  gl_FragColor *= vec4(factorN, factorN, factorN, 1.0);
  }
  else if(scale > 5.0 && scale <= 10.0){
  gl_FragColor = texture2D(myTexture[1], vsoTexCoord);
  gl_FragColor *= vec4(factor, factor, factor, 1.0);
  gl_FragColor *= vec4(factorN, factorN, factorN, 1.0);
  }

  else if(scale > 10.0 && scale <= 30.0){
  gl_FragColor = texture2D(myTexture[2], vsoTexCoord);
  gl_FragColor *= vec4(factor, factor, factor, 1.0);
  gl_FragColor *= vec4(factorN, factorN, factorN, 1.0);
  }

  else if(scale > 30.0 && scale <= 50.0){
  gl_FragColor = texture2D(myTexture[3], vsoTexCoord);
  gl_FragColor *= vec4(factor, factor, factor, 1.0);
  gl_FragColor *= vec4(factorN, factorN, factorN, 1.0);
  }
  else{
  gl_FragColor = texture2D(myTexture[4], vsoTexCoord);
  gl_FragColor *= vec4(factor, factor, factor, 1.0);
  gl_FragColor *= vec4(factorN, factorN, factorN, 1.0);
  }

}
