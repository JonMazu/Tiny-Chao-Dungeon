import struct
import socket
testDir = "G:/Games/Steam/steamapps/common/Sonic Adventure 2/resource/gd_PC/SAVEDATA/SONIC2B__ALF"
gardenOffset  = 0x3AB0
chaoOffset = 0x800
StatsOffset = {
    "name" : 0x12,
    "SwimLevel" : 0x24,
    "FlyLevel" : 0x25,
    "RunLevel" : 0x26,
    "PowerLevel" : 0x27,
    "StaminaLevel" : 0x28,
    "SwimPoints" : 0x2C,
    "FlyPoints" : 0x2E,
    "RunPoints" : 0x30,
    "PowerPoints" : 0x32,
    "StaminaPoints" : 0x34,
}
file =  open(testDir,"rb")
#file.seek((gardenOffset+6)+0x800)
#print(gardenOffset+0x800)
#print(file.read(7))
file.seek(0x3AB0+0x800)
print(hex(0x3AB0+0x800+0x28))
testArray =  ["SwimPoints","FlyPoints", "RunPoints","PowerPoints","StaminaPoints"]
powerArray = []
for x in testArray:
    file.seek(gardenOffset+chaoOffset+StatsOffset[x])
    tempStore = file.read(1).hex()
    print(tempStore)
    file.seek(gardenOffset+chaoOffset+StatsOffset[x]+1)
    powerArray.append(file.read(1).hex()+tempStore)
levelArray = []
testArray =  ["SwimLevel","FlyLevel", "RunLevel","PowerLevel","StaminaLevel"]
for x in testArray:
    file.seek(gardenOffset+chaoOffset+StatsOffset[x])
    levelArray.append(int("0x"+file.read(1).hex(),16))
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as o:
        #s.bind(("localhost",3246))
        waiting = True
        '''while(waiting):
            try:
                conn, addr = s.accept()
                waiting = False
            except:
                print('no')'''
        o.connect(("127.0.0.1",3245))
        for x in levelArray:
            o.sendall(x.to_bytes(1,'big'))
        for x in powerArray:
            print(x)
            o.sendall(bytes.fromhex(x))
        '''conn, addr = s.accept()
        with conn:
            while True:
                data = conn.recv(1024)
                if not data:
                    break
                print(data)'''

