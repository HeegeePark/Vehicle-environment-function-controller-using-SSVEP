#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
#include <avr/power.h>
#endif
#define PIN 6
Adafruit_NeoPixel strip = Adafruit_NeoPixel(80, PIN, NEO_GRB + NEO_KHZ800);

int state = -1;
void setup() {
  Serial.begin(9600);
  pinMode(6, OUTPUT);
}

void loop() {
    if(Serial.available() > 0) {
      int token = Serial.read();
      if(token == 49) {
        state = 1;
      }
      else if(token == 50) {
        state = -1;
      }
    }
    
   if(state == 1)
    { 
      strip.begin();
      strip.setBrightness(30);
      strip.show(); // Initialize all pixels to 'off'
      //digitalWrite(13, HIGH);
      for(int i=0; i<strip.numPixels(); i++)
      {
        strip.setPixelColor(i,120,180,0);
      }
      strip.show();
    }
    else 
    {
            strip.begin();
      strip.setBrightness(0);
      strip.show(); // Initialize all pixels to 'off'
      //digitalWrite(13, HIGH);
      for(int i=0; i<strip.numPixels(); i++)
      {
        strip.setPixelColor(i,120,180,0);
      }
      strip.show();
      //digitalWrite(13, LOW);
    }
}
