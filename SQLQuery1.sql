Select *from [F0001].[dbo].[agr]
Where EmpNo = 26 and frdt = 20121212

Select AgrActNo, AgrNo, FrDt, Invo, EmpNo from [F0001].[dbo].[agr]
Where EmpNo = 26

Update [F0001].[dbo].[agr]
set R5 = 1
where EmpNo = 26 and AgrActNo = 6 and FrDt = 20121212 and AgrNo = 250
