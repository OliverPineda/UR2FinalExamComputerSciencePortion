// Pin number for the onboard LED
const int ledPin = 13;

void setup() {
  // Initialize serial communication at 9600 baud
  Serial.begin(9600);

  // Set the LED pin as an output
  pinMode(ledPin, OUTPUT);

  // Initial state: LED off
  digitalWrite(ledPin, LOW);

  // Display initial message in Serial Monitor
  Serial.println("Enter 0 to turn off the LED, 1 to turn it on.");
}

void loop() {
  // Check if data is available to read from Serial Monitor
  if (Serial.available() > 0) {
    // Read the incoming byte
    char incomingByte = Serial.read();

    // Check the value received
    if (incomingByte == '0') {
      // Turn off the LED
      digitalWrite(ledPin, LOW);
      Serial.println("LED turned off.");
    } else if (incomingByte == '1') {
      // Turn on the LED
      digitalWrite(ledPin, HIGH);
      Serial.println("LED turned on.");
    } else {
      // Invalid input
      Serial.println("Invalid input. Enter 0 to turn off the LED, 1 to turn it on.");
    }
  }
}
