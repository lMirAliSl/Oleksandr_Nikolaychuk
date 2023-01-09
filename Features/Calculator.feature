Feature: CreatingShiftName

Scenario: ShiftNameAdd
Given login in accaount
| UserName | Password |
| Admin | admin123 |
When click on admin
And click on job and shiftname
And click on add
And write information
| ShiftName | AssignedEmployees |
| Oleksandr   | Odis Adalwin | 
And click on save
Then delete shiftname
