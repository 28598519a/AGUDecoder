# AGUDecoder
用於解密 姬械聯盟：藍星危機 (Armed Girls Union)

解密部分是利用IDA Pro逆向libcocos2djs.so出彙編碼後修改而成，此遊戲應該是使用Cocos Creator 2.4.3製作

遊戲本體大包內的assets\res\內的檔案可以用assets\resData內的table修正檔案路徑跟名稱 (會與update/相同格式)，但進一步還原檔案名稱我目前沒頭緒 (config.json估計占一部分)，如果你知道怎麼還原檔案名稱的話，希望開個issue告知我

## jsc

此程式不包含jsc解密，但我提供解密用的Key

Key: renrengame

![](https://user-images.githubusercontent.com/33422418/214646726-0a420d6a-9c54-47cd-bb6f-4e77ca0fe205.png)

## 使用
先選資料夾，在按解密 (雖然有驗標頭，但他標頭是"encode"，我覺得這個開頭有機率撞到，所以資料夾不要亂選)
![](https://user-images.githubusercontent.com/33422418/214648457-ec33384a-d949-4b04-86e1-f89c779711e4.png)

Required : .net 6 及 Visual Studio C++ 2022
