# 12 Codes of Christmas - cs-mas.xyz

## Solutions in this repo
  
- AdditiveProblem
- KingsProblem
- MatryoshkaProblem
- RandomStreamStatisticsProblem
- SleighBellProblem

These are located in each their own .cs file.

The IAmLateProblem came out well... late, I didn't have soo much time to spend on trying to solve it, and what i did unfortunately only worked locally.  

---

## Flags

A Flag was hidden in a jwt cookie you get when visiting cs-mas.xyz

```html
Set-Cookie: accessToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmbGFnIjoiNGNkZmEwYWUtZjE0Zi00N2IwLWFiODEtNzY2MmUwYjdkMmQzIn0.Q0_fMQaUKPUJV9yDa_enK3yp4IPSCeDXffD4DrcZbGA; path=/
```

Decoding from base64 or jwt decoder gives a flag

```html
jwt decoder
{"flag": "4cdfa0ae-f14f-47b0-ab81-7662e0b7d2d3"}

base64 decoded
{"alg":"HS256","typ":"JWT"}{"flag":"4cdfa0ae-f14f-47b0-ab81-7662e0b7d2d3"}.Ñó.iB.P.}È6...ò§..H'.]÷Ãà:Üe±.
```

---

Flag which was located in the input.json of matryoshkaproblem

While doing the challenge simple check for more than one element in "data"

```csharp
if (obj.Data.Count > 1)
{
    for (int i = 1; i < obj.Data.Count; i++)
    {
        Console.WriteLine($"Found a odd thing: {JsonConvert.SerializeObject(obj.Data[i])}");
    }
}
```

This flag got printed after a short time

```html
{"flag":"b53f7327-fda7-490f-9b0c-a64c5c950142"}
```

---

Flag which located on the disk

Path: /happy-xmas

```html
b60c0b28-6041-4d10-b4d1-6ed4df5580a3
```

---

The KingsProblem input was a url, and poking around with this challenge revealed that the webservers root was a directory view.

```html
http://192.168.0.101/flag
f2e482be-4a92-4535-80d2-16bf1a6dd6df
```

---

While Enumerating and solving problems, there was quite a few machines present on this network.

I did some async ping discovery on the `192.168.0.0/24` subnet to discover other hosts.

Which did come back with like 17 online hosts.

From here i reused stuff from the problems, because it seemed unreasonable doing 65535 ports in 30 sec before the timeout.

Trying out to see if port 2424 or 4242 was open just in case from the RandomStreamStatisticsProblem, where 2424 was only open on the host for that challenge.

Next I tried sending http requests out to all these hosts testing common webserver ports.

This discovered a webserver on ip `192.168.0.201`

```html
http://192.168.0.201/flag.txt
2679cebd-6a36-41d3-aa0d-a67ef8ed6985
```

---

Also when i visited to pickup my 3rd place price, i got informed that if i had posted content of the Christmas tree you're greeted with on cs-mas.xyz i would've had all 6 flags :o
