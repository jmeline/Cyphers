#!/usr/bin/env python3

'''
The Bifid Cipher uses a Polybius Square to encipher a message in a way that 
makes it fairly difficult to decipher without knowing the secret. 

https://www.braingle.com/brainteasers/codes/bifid.php
'''

import numpy as np

class BifidCipher():
    
    def __init__(self):
        Square = [['a','b','c','d','e'],
                  ['f','g','h','i','k'],
                  ['l','m','n','o','p'],
                  ['q','r','s','t','u'],
                  ['v','w','x','y','z']]
        self.Square = np.array(Square)
    
    def LetterToNumbers(self, Letter):
        Index1, Index2 = np.where(self.Square == Letter)
        Indexes = np.concatenate([Index1, Index2])
        return Indexes

    def NumbersToLetter(self, Index1, Index2):
        Letter = self.Square[Index1, Index2]
        return Letter
        
    def Encode(self, Message):
        Message = Message.lower()
        Message = Message.replace(' ', '')
        
        FirstStep = np.empty((2, len(Message)))
        for LetterIndex in range(len(Message)):
            Numbers = self.LetterToNumbers(Message[LetterIndex])

            FirstStep[0, LetterIndex] = Numbers[0]
            FirstStep[1, LetterIndex] = Numbers[1]
            
        
        SecondStep = FirstStep.reshape(2 * len(Message))
        EncodedMessage = ''
        for NumbersIndex in range(len(Message)):
            Index1 = int(SecondStep[NumbersIndex * 2])
            Index2 = int(SecondStep[(NumbersIndex * 2) + 1])
            Letter = self.NumbersToLetter(Index1, Index2)
            EncodedMessage = EncodedMessage + Letter
        
        return EncodedMessage
    
    def Decode(self, Message):
        Message = Message.lower()
        Message.replace(' ', '')
        FirstStep = np.empty(2 * len(Message))
        for LetterIndex in range(len(Message)):
            Numbers = self.LetterToNumbers(Message[LetterIndex])
            FirstStep[LetterIndex * 2] = Numbers[0]
            FirstStep[LetterIndex * 2 + 1] = Numbers[1]
            
        SecondStep = FirstStep.reshape((2, len(Message)))
        DecodedMessage = ''
        for NumbersIndex in range(len(Message)):
            Index1 = int(SecondStep[0, NumbersIndex])
            Index2 = int(SecondStep[1, NumbersIndex])
            Letter = self.NumbersToLetter(Index1, Index2)
            DecodedMessage = DecodedMessage + Letter
            
        return DecodedMessage