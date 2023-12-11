const int ledPin = 13;  // Pin connected to the LED

void setup() {
  pinMode(ledPin, OUTPUT); // Initialize the digital pin as an output
  Serial.begin(9600); // Initialize serial communication at 9600 baud
}

void loop() {
  if (Serial.available() > 0) {
    int mType = Serial.parseInt(); // Read the number of contours from serial

    // Check the shape based on contours count
    if (mType > 0) 
    {
      if (mType == 2) {
        // Triangle detected, turn on the LED
        digitalWrite(ledPin, HIGH);
        delay(2000); // Keep the LED on for 2 seconds
        digitalWrite(ledPin, LOW); // Turn off the LED
        
      } else if (mType == 3) 
      {
        // Square detected, turn on the LED
        digitalWrite(ledPin, HIGH);
        delay(2000); // Keep the LED on for 2 seconds
        digitalWrite(ledPin, LOW); // Turn off the LED
      }
    }
  }
}
