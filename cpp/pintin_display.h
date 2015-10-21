#ifndef PINTIN_DISPLAY_H
#define PINTIN_DISPLAY_H

#define PINTINDISPLAY_API __attribute__((visibility("default")))

using namespace std;

// Define an edOLED object:
class PINTINDISPLAY_API PinTinDisplay
{
public:
	PinTinDisplay();
	~PinTinDisplay();

	void begin(void);
	int menu(void);
	char* CallGetUserTextInput(char* title);
	void CallDisplayOkMessage(char* title);
	void DisplayMessage(char* message);
	void ClearDisplay(void);
	int DisplayEntries(char** entries, int count);
	int DisplayEntry(char* uri, char* username, char* password, char* note);
private:
	edOLED oled;
	
	// Pin definitions:
	// All buttons have pull-up resistors on-board, so just declare
	// them as regular INPUT's
	/*gpio buttonUp;
	gpio buttonDown;
	gpio buttonLeft;
	gpio buttonRight;
	gpio buttonSelect;
	gpio buttonA;
	gpio buttonB;*/
	/*gpio BUTTON_UP(47, INPUT);
	gpio BUTTON_DOWN(44, INPUT);
	gpio BUTTON_LEFT(165, INPUT);
	gpio BUTTON_RIGHT(45, INPUT);
	gpio BUTTON_SELECT(48, INPUT);
	gpio BUTTON_A(49, INPUT);
	gpio BUTTON_B(46, INPUT);*/
	//gpio buttonB;
};

#endif
