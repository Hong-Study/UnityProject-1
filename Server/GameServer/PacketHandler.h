#pragma once

class PacketHandler
{
public:
	static void Serialized() {

	}
};

#pragma pack(push)
#pragma pack(1)
typedef struct socket_data {
	DWORD msg;
	WORD size;
	WORD type;
	char data[128];
}SOCKET_DATA;
#pragma pack(pop)

