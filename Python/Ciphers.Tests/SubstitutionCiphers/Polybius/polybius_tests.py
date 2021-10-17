#!/usr/bin/env python3

import polybius
import numpy as np

Cipher = polybius.PolybiusCipher()

assert (np.array_equal(Cipher.letter_to_numbers('a'), [1,1]))
assert (np.array_equal(Cipher.letter_to_numbers('u'), [4,5]))

assert (Cipher.numbers_to_letter(4, 5) == "u")
assert (Cipher.numbers_to_letter(1, 1) == "a")

assert (Cipher.encode("test message") == "44154344 32154343112215")
assert (Cipher.encode("Test Message") == "44154344 32154343112215")

assert (Cipher.decode("44154344 32154343112215") == "test message")
assert (Cipher.decode("4415434432154343112215") == "testmessage")