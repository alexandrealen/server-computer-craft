-- https://pastebin.com/CeeK2KNe

local function getFile(port)
    print("Connecting")
    local req = http.get("http://localhost:" .. port)    
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

local file = getFile(4546)
saveFile(file, "run")
 
