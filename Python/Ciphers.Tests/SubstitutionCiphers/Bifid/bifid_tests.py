#!/usr/bin/env python3
import os

os.chdir('../../..')
os.chdir('Ciphers/SubstitutionCiphers/Bifid')

import Bifid

Cipher = Bifid.BifidCipher()

assert (Cipher.encode('testmessage') == 'qtltbdxrxlk')
assert (Cipher.encode('test message') == 'qtltbdxrxlk')
assert (Cipher.encode('Test Message') == 'qtltbdxrxlk')
assert (Cipher.encode('') == '')

assert (Cipher.decode('qtltbdxrxlk') == 'testmessage')
assert (Cipher.decode('') == '')
