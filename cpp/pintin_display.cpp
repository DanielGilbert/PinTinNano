#include <iostream>
#include "oled/Edison_OLED.h"
#include "gpio/gpio.h"
#include "math.h"
#include <unistd.h> // for usleep
#include <stdlib.h> // Gives us atoi
#include <cstring>
#include <stdio.h>
#include "pintin_display.h"

using namespace std;

gpio BUTTON_UP(47, INPUT);
gpio BUTTON_DOWN(44, INPUT);
gpio BUTTON_LEFT(165, INPUT);
gpio BUTTON_RIGHT(45, INPUT);
gpio BUTTON_SELECT(48, INPUT);
gpio BUTTON_A(49, INPUT);
gpio BUTTON_B(46, INPUT);

PinTinDisplay::PinTinDisplay()
{
}

PinTinDisplay::~PinTinDisplay()
{
}


void PinTinDisplay::begin(void)
{
	this->oled.begin();
	this->oled.clear(PAGE);
	this->oled.setFontType(0);
	this->oled.print("Hi :)");
	this->oled.display();
	sleep(2);
	this->oled.clear(PAGE);
	this->oled.display();

}

int PinTinDisplay::menu(void)
{
	bool isConfirmed = false;
	bool buttonHasBeenReleased = false;
	int currentRow = 0;
	
	while(!isConfirmed)
	{
		usleep(2000);
		
		if (BUTTON_UP.pinRead() == HIGH &&
		BUTTON_DOWN.pinRead() == HIGH &&
		BUTTON_SELECT.pinRead() == HIGH)
			buttonHasBeenReleased = true;
		
		oled.setCursor(0, 0);
		oled.clear(PAGE);
		if (currentRow == 0)
			oled.print(">     LIST");
		else
			oled.print("      List");
		if (currentRow == 1)
			oled.print(">     FIND");
		else
			oled.print("      Find");
		oled.print("----------");
		if (currentRow == 2)
			oled.print(">      NEW");
		else
			oled.print("       New");
		if (currentRow == 3)
			oled.print(">     EDIT");
		else
			oled.print("      Edit");
		if (currentRow == 4)
			oled.print(">   DELETE");
		else
			oled.print("    Delete");
		
		oled.display();
		
		if (BUTTON_UP.pinRead() == LOW && buttonHasBeenReleased){
			currentRow--;
			if (currentRow < 0){
				currentRow = 4;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_DOWN.pinRead() == LOW && buttonHasBeenReleased){
			currentRow++;
			if (currentRow > 4){
				currentRow = 0;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_SELECT.pinRead() == LOW && buttonHasBeenReleased){
			buttonHasBeenReleased = false;
			oled.clear(PAGE);
			oled.display();
			return currentRow;
		}
	}
}

char* PinTinDisplay::CallGetUserTextInput(char* title)
{
	string test = "";
	const int verticalOffset = 24;
	int currentRow = 0;
	int currentCol = 0;
	bool isConfirmed = false;
	bool buttonHasBeenReleased = false;
	int currentCharSet = 0;
	const char smallAlphabet[3][10] = {{'a','b','c','d','e','f','g','h','i','j'},
							 {'k','l','m','n','o','p','q','r','s','t'},
							 {'u','v','w','x','y','z',' ',' ','<','y'}};
							 
	const char largeAlphabet[3][10] = {{'A','B','C','D','E','F','G','H','I','J'},
							 {'K','L','M','N','O','P','Q','R','S','T'},
							 {'U','V','W','X','Y','Z',' ',' ','<','y'}};
							 
	const char specialNumeric[3][10] = {{'1','2','3','4','5','6','7','8','9','0'},
							 {'+','-','/','*','{','}','(',')','%','$'},
							 {':','!','?','.',',','_','#',' ','<','y'}};

	while(!isConfirmed)
	{
		this->oled.setCursor(0, 0);
		this->oled.clear(PAGE);
		oled.print(title);
		this->oled.setCursor(0, 8);
		oled.print(test.c_str());
		this->oled.setCursor(0, verticalOffset);
							 
		for(int row = 0; row < 3; row++)
			for(int col = 0; col < 10; col++)	
				if ((currentRow == row) && (currentCol == col))
				{
					this->oled.rectFill((currentCol * 6), (verticalOffset + currentRow * 8), 5, 8);
					this->oled.setCursor((currentCol * 6), (verticalOffset + currentRow * 8));
					this->oled.setDrawMode(XOR);
					if (currentCharSet == 0)
						this->oled.write(smallAlphabet[row][col]);
					if (currentCharSet == 1)
						this->oled.write(largeAlphabet[row][col]);
					if (currentCharSet == 2)
						this->oled.write(specialNumeric[row][col]);
					this->oled.setDrawMode(NORM);
				}
				else
				{
					if (currentCharSet == 0)
						this->oled.write(smallAlphabet[row][col]);
					if (currentCharSet == 1)
						this->oled.write(largeAlphabet[row][col]);
					if (currentCharSet == 2)
						this->oled.write(specialNumeric[row][col]);
				}

		this->oled.display();
		
		//Draw the selection
		if (BUTTON_RIGHT.pinRead() == LOW && buttonHasBeenReleased){
			currentCol++;
			if (currentCol > 9){
				currentRow++;
				currentCol = 0;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_LEFT.pinRead() == LOW && buttonHasBeenReleased){
			currentCol--;
			if (currentCol < 0){
				currentRow--;
				currentCol = 9;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_UP.pinRead() == LOW && buttonHasBeenReleased){
			currentRow--;
			if (currentRow < 0){
				currentRow = 2;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_DOWN.pinRead() == LOW && buttonHasBeenReleased){
			currentRow++;
			if (currentRow > 2){
				currentRow = 0;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_A.pinRead() == LOW && buttonHasBeenReleased){
			currentCharSet--;
			if (currentCharSet < 0)
				currentCharSet = 2;
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_B.pinRead() == LOW && buttonHasBeenReleased){
			currentCharSet++;
			if (currentCharSet > 2)
				currentCharSet = 0;
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_SELECT.pinRead() == LOW && buttonHasBeenReleased){
			//test = test + smallAlphabet[currentRow][currentCol];
			if (currentRow == 2 && currentCol == 9){
				//return vector<char> chars(test.c_str(), test.c_str() + test.size() + 1u);;
				char *s = (char*)malloc(strlen(test.c_str())+1);
				// if you write char s[strlen(q)], it is defined locally, and thus on return gives an undefined behaviour
				int i;
				for(i = 0; i < strlen(test.c_str())+1; i++)
					s[i] = test[i];
				//return s;
				//char *s = strdup(test);
				oled.clear(PAGE);
				oled.display();
				return s;
			}
			if (currentCharSet == 0)
				test.push_back(smallAlphabet[currentRow][currentCol]);
			if (currentCharSet == 1)
				test.push_back(largeAlphabet[currentRow][currentCol]);
			if (currentCharSet == 2)
				test.push_back(specialNumeric[currentRow][currentCol]);

			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_UP.pinRead() == HIGH &&
			BUTTON_DOWN.pinRead() == HIGH &&
			BUTTON_RIGHT.pinRead() == HIGH &&
			BUTTON_LEFT.pinRead() == HIGH &&
			BUTTON_SELECT.pinRead() == HIGH &&
			BUTTON_A.pinRead() == HIGH &&
			BUTTON_B.pinRead() == HIGH)
			buttonHasBeenReleased = true;
	
	}
}

void PinTinDisplay::CallDisplayOkMessage(char* title)
{
	bool isConfirmed = false;
	bool buttonHasBeenReleased = false;
	int currentRow = 0;
	
	this->oled.setCursor(0, 0);
	this->oled.clear(PAGE);
	oled.print(title);
	this->oled.setCursor(48, 40);
	this->oled.print("OK");
	this->oled.setDrawMode(XOR);
	this->oled.rectFill(46, 38, 14, 12);
	this->oled.setDrawMode(NORM);
	this->oled.display();
					
	while(!isConfirmed)
	{
		usleep(2000);
		
		if (BUTTON_UP.pinRead() == HIGH &&
		BUTTON_DOWN.pinRead() == HIGH &&
		BUTTON_SELECT.pinRead() == HIGH)
			buttonHasBeenReleased = true;

		if (BUTTON_SELECT.pinRead() == LOW && buttonHasBeenReleased){
			buttonHasBeenReleased = false;
			isConfirmed = true;
		}
	}
}

void PinTinDisplay::DisplayMessage(char* message)
{
	this->oled.setCursor(0, 0);
	this->oled.clear(PAGE);
	this->oled.print(message);
	this->oled.display();	
}

void PinTinDisplay::ClearDisplay(void)
{
	this->oled.setCursor(0, 0);
	this->oled.clear(PAGE);
	this->oled.display();	
}

int PinTinDisplay::DisplayEntries(char** entries, int count)
{
	int selectedEntry = 0;
	int currentPage = 1;
	int totalPages = 1;
	int currentEntry = 0;
	int currentPageEntry = 0;
	int entriesPerPage = 5;
	bool entrySelected = false;
	bool buttonHasBeenReleased = false;
	
	totalPages = (count / entriesPerPage) + 1;

	do{
		usleep(2000);

		this->oled.setCursor(0, 0);
		this->oled.clear(PAGE);
		
		int upperBound = (currentPage * entriesPerPage);
		if (upperBound >= count)
			upperBound = count;
		
		int n = 0;
		
		for(int i = ((currentPage * entriesPerPage) - entriesPerPage); i < upperBound; i++) {
			
			if(i == currentEntry)
			{
				this->oled.setCursor(0, n * 9 - n);
				this->oled.print(">");
				this->oled.setCursor(6, n * 9 - n);
				this->oled.print(entries[i]);
			}
			else
			{
				this->oled.setCursor(0, n * 9 - n);
				this->oled.print(" ");
				this->oled.setCursor(6, n * 9 - n);
				this->oled.print(entries[i]);	
			}
			
			n++;
		}
		this->oled.setCursor(0, 40);
		this->oled.print("Page: ");
		this->oled.print(currentPage);
		this->oled.print("/");
		this->oled.print(totalPages);
		this->oled.display();	
		
		
		//Draw the selection
	
		if (BUTTON_LEFT.pinRead() == LOW && buttonHasBeenReleased){
			return -1;
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_UP.pinRead() == LOW && buttonHasBeenReleased){
			currentEntry--;
			currentPageEntry--;
			if (currentPageEntry < 0){
				currentPageEntry = entriesPerPage - 1;
				currentEntry = upperBound - 1;
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_DOWN.pinRead() == LOW && buttonHasBeenReleased){
			currentEntry++;
			currentPageEntry++;
			if (currentPageEntry > entriesPerPage - 1){
				currentPageEntry = 0;
				currentEntry = ((currentPage * entriesPerPage) - entriesPerPage); 
			}
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_A.pinRead() == LOW && buttonHasBeenReleased){
			currentPage--;
			currentPageEntry = 0;
			if (currentPage < 1)
				currentPage = totalPages;
			currentEntry = ((currentPage * entriesPerPage) - entriesPerPage); 
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_B.pinRead() == LOW && buttonHasBeenReleased){
			currentPage++;
			currentPageEntry = 0;
			if (currentPage > totalPages)
				currentPage = 1;
			currentEntry = ((currentPage * entriesPerPage) - entriesPerPage); 
			buttonHasBeenReleased = false;
		}
		
		if ((BUTTON_SELECT.pinRead() == LOW && buttonHasBeenReleased) || (BUTTON_RIGHT.pinRead() == LOW && buttonHasBeenReleased)){
			return currentEntry;
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_UP.pinRead() == HIGH &&
			BUTTON_DOWN.pinRead() == HIGH &&
			BUTTON_RIGHT.pinRead() == HIGH &&
			BUTTON_LEFT.pinRead() == HIGH &&
			BUTTON_SELECT.pinRead() == HIGH &&
			BUTTON_A.pinRead() == HIGH &&
			BUTTON_B.pinRead() == HIGH)
			buttonHasBeenReleased = true;
		
	} while (!entrySelected);
	
	
	return currentEntry * (currentPage + 1);
}

int PinTinDisplay::DisplayEntry(char* uri, char* username, char* password, char* note)
{
	int currentPage = 1;
	int totalPages = 4;
	bool isReturning = false;
	bool buttonHasBeenReleased = false;
	
	do{
		usleep(2000);
		
		this->oled.setCursor(0, 0);
		this->oled.clear(PAGE);
		
		switch(currentPage){
			case 1:
				this->oled.print("Uri:");
				this->oled.setCursor(0, 8);
				this->oled.print(uri);
			break;
			
			case 2:
				this->oled.print("Username:");
				this->oled.setCursor(0, 8);
				this->oled.print(username);
			break;
			
			case 3:
				this->oled.print("Password");
				this->oled.setCursor(0, 8);
				this->oled.print(password);
			break;
			
			case 4:
				this->oled.print("Note:");
				this->oled.setCursor(0, 8);
				this->oled.print(note);
			break;
		}

		this->oled.display();
		//Draw the selection
	
		if (BUTTON_LEFT.pinRead() == LOW && buttonHasBeenReleased){
			isReturning = true;
			buttonHasBeenReleased = false;
		}

		if (BUTTON_A.pinRead() == LOW && buttonHasBeenReleased){
			currentPage--;
			if (currentPage < 1)
				currentPage = totalPages;
			buttonHasBeenReleased = false;
		}
		
		if (BUTTON_B.pinRead() == LOW && buttonHasBeenReleased){
			currentPage++;
			
			if (currentPage > totalPages)
			{
				currentPage = 1;
			}
			
			buttonHasBeenReleased = false;
		}

		if (BUTTON_UP.pinRead() == HIGH &&
			BUTTON_DOWN.pinRead() == HIGH &&
			BUTTON_RIGHT.pinRead() == HIGH &&
			BUTTON_LEFT.pinRead() == HIGH &&
			BUTTON_SELECT.pinRead() == HIGH &&
			BUTTON_A.pinRead() == HIGH &&
			BUTTON_B.pinRead() == HIGH)
			buttonHasBeenReleased = true;
		
	} while (!isReturning);
	
	
	return -1;
}