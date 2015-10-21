#ifndef PINTIN_DISPLAY_WRAPPER_H
#define PINTIN_DISPLAY_WRAPPER_H

#include <iostream>
#include "oled/Edison_OLED.h"
#include "gpio/gpio.h"
#include "math.h"
#include <unistd.h> // for usleep
#include <stdlib.h> // Gives us atoi
#include <stdio.h>
#include "pintin_display.h"



extern "C" {
	extern PINTINDISPLAY_API PinTinDisplay* CreatePinTinDisplay();
	extern PINTINDISPLAY_API void DisposePinTinDisplay(PinTinDisplay* pObject);

	extern PINTINDISPLAY_API void CallBegin(PinTinDisplay* pObject);
	extern PINTINDISPLAY_API int CallMenu(PinTinDisplay* pObject);
	extern PINTINDISPLAY_API char* CallGetUserTextInput(PinTinDisplay* pObject, char* title);
	extern PINTINDISPLAY_API void CallDisplayOkMessage(PinTinDisplay* pObject, char* message);
	extern PINTINDISPLAY_API void CallDisplayMessage(PinTinDisplay* pObject, char* message);
	extern PINTINDISPLAY_API void CallClearDisplay(PinTinDisplay* pObject);
	extern PINTINDISPLAY_API int CallDisplayEntries(PinTinDisplay* pObject, char** entries, int count);
	extern PINTINDISPLAY_API int CallDisplayEntry(PinTinDisplay* pObject, char* uri, char* username, char* password, char* note);
}

#endif