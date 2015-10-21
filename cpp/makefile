CC=g++
CFLAGS=-c -Wall
LDFLAGS=-shared
SOURCES=spi/spi_port_edison.cpp spi/spi_device_edison.cpp pintin_display.cpp pintin_display_wrapper.cpp oled/Edison_OLED.cpp gpio/gpio_edison.cpp
OBJECTS=$(SOURCES:.cpp=.o)
EXECUTABLE=libpintin_display.so

all: $(SOURCES) $(EXECUTABLE)
	
$(EXECUTABLE): $(OBJECTS) 
	$(CC) $(LDFLAGS) $(OBJECTS) -o $@

.cpp.o:
	$(CC) $(CFLAGS) $< -o $@

clean:
	rm -rf *.o $(EXECUTABLE)