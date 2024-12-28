-- https://pastebin.com/CeeK2KNe

local function getFile(port)
    print("Connecting")
    local req = http.get("http://localhost:4546")
    if req == nil then
      print("Cannot connect")
      return
    end
    return req.readAll()
end
 
 
local function saveFile(file, filename)
    local f = fs.open(filename, "w")
    f.write(file)
    f.close()
end
 
local file = getFile(8080)
saveFile(file, "teste.lua")
 