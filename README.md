Contents
========
This repository contains a .NET SDK for integrating with [DocData Payments](http://www.docdatapayments.com/nl)

It consists of

1. A .NET SDK
2. A .NET Example showing how to use the .NET SDK

The lack of documentation is obvious, yet hopefully by diving in the code of the example project it will be self-explanatory.

Besides the basic DocData payment example (`PaymentExampleNoToken.aspx`) and how to deal with a status update 'poke' from DocData (`PaymentStateChangedExample.aspx.cs`) there is also an example on how to use DocData in combination with [linkID](https://github.com/link-nv/linkid-sdk).
Have a look at `PaymentExample.aspx` and `PaymentExampleRecurrent.aspx` for this.
