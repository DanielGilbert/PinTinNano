#include "pintin_display_wrapper.h"

extern "C" PINTINDISPLAY_API PinTinDisplay* CreatePinTinDisplay()
{
	return new PinTinDisplay();
}

extern "C" PINTINDISPLAY_API void DisposePinTinDisplay(
	PinTinDisplay* pObject)
{
	if (pObject != NULL)
	{
		delete pObject;
		pObject = NULL;
	}
}

extern "C" PINTINDISPLAY_API void CallBegin(PinTinDisplay* pObject)
{
	if (pObject != NULL)
	{
		pObject->begin();
	}
}

extern "C" PINTINDISPLAY_API int CallMenu(PinTinDisplay* pObject)
{
	if (pObject != NULL)
	{
		return pObject->menu();
	}
	return -1;
}

extern "C" PINTINDISPLAY_API char* CallGetUserTextInput(PinTinDisplay* pObject, char* title)
{
	if (pObject != NULL)
	{
		return pObject->CallGetUserTextInput(title);
	}
	return NULL;
}

extern PINTINDISPLAY_API void CallDisplayOkMessage(PinTinDisplay* pObject, char* message)
{
	if (pObject != NULL)
	{
		return pObject->CallDisplayOkMessage(message);
	}
}

extern PINTINDISPLAY_API void CallDisplayMessage(PinTinDisplay* pObject, char* message)
{
	if (pObject != NULL)
	{
		return pObject->DisplayMessage(message);
	}
}

extern PINTINDISPLAY_API void CallClearDisplay(PinTinDisplay* pObject)
{
	if (pObject != NULL)
	{
		return pObject->ClearDisplay();
	}
}

extern PINTINDISPLAY_API int CallDisplayEntries(PinTinDisplay* pObject, char** entries, int count)
{
	if (pObject != NULL)
	{
		return pObject->DisplayEntries(entries, count);
	}
}

extern PINTINDISPLAY_API int CallDisplayEntry(PinTinDisplay* pObject, char* uri, char* username, char* password, char* note)
{
	if (pObject != NULL)
	{
		return pObject->DisplayEntry(uri, username, password, note);
	}	
}