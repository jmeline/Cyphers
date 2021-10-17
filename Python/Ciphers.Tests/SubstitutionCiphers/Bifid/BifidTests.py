#!/usr/bin/env python3
import Bifid

Cipher = Bifid.BifidCipher()

assert (Cipher.Encode('testmessage') == 'qtltbdxrxlk')
assert (Cipher.Encode('test message') == 'qtltbdxrxlk')
assert (Cipher.Encode('Test Message') == 'qtltbdxrxlk')
assert (Cipher.Encode('') == '')

assert (Cipher.Decode('qtltbdxrxlk') == 'testmessage')
assert (Cipher.Decode('') == '')