# Python Cyphers

## Instructions

### Using the cyphers
To use one of the cyphers, you first need to import its .py file. To do that, you can use the following commands inside your code:
```
import os
mycwd = os.getcwd()
os.chdir(Python Cipher Path)
import CipherName
os.chdir(mycwd)
```
Before running the commands, remember to replace Python Cipher Path with the path to the cipher that you want to use (for example, /home/user/Git Repos/Cyphers/Python/Ciphers/SubstitutionCiphers/Bifid) and CipherName with the name of the cipher that you are importing (in this case, bifid).

After doing this, you will be able to create an object that contains the encoding and decoding functions. For example, to create a Bifid cipher object you can write (To use other cyphers, just replace "bifid" and the desired cipher name):
```
cipher = Bifid.BifidCipher()
```
From here, the encoding and decoding of any message can be done by calling the respective function:
```
encoded_message = cipher.encode(message_to_encode)
decoded_message = cipher.decode(message_to_decode)
```
### Testing the cyphers
To run the tests of a specific cipher, you can navigate to its folder using the terminal and run it by using:
```
python3 cipher_tests.py
```
Before running the command above, remember to replace cipher_tests.py with the name of the test file you want to run.
