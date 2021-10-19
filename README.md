# Cyphers [![.NET](https://github.com/jmeline/Cyphers/actions/workflows/dotnet.yml/badge.svg)](https://github.com/jmeline/Cyphers/actions/workflows/dotnet.yml)
Let's build some Cyphers in C#

## What is a Cipher?
An algorithm for performing encryption or decryption. It is one of the many facinating areas of study in classical cryptography. https://en.wikipedia.org/wiki/Cipher for more information!

## Cipher.CLI

This is a console application build with [System.CommandLine](https://github.com/dotnet/command-line-api) that allows to use the implemented ciphers.

To list the available ciphers:

```
$cyphers
```

To encode and decode morse code:
```
$cyphers morse-code -e hello
.... . .-.. .-.. ---

$cyphers morse-code -d ".... . .-.. .-.. ---"
hello
```

Some command may require extra options. Use them as follows:

```
$cyphers keyword
You must specify either the 'decode' or 'encode' option.
Option '-k' is required.

keyword
  Keyword sipher.

Usage:
  cyphers [options] keyword

Options:
  -d, --decode <decode>
  -e, --encode <encode>
  -k, --keyword <keyword> (REQUIRED)  Keyword.
  -?, -h, --help                      Show help and usage information

$cyphers keyword -k c -e abc
cab

$cyphers keyword -k c -d cab
abc
```