# The Robot Factory

The Regent of Dynamak is impressed with your dynamic skills and has asked for your help to bring their robot factory back online. It was damaged in the Uncoded One's arrival. Robots are manufactured after collecting their details, all of which are optional except for a numeric ID. After the information is collected, the robot is created by displaying the robot's details in the console. Here are two examples:

```
You are producing robot #1
Do you want to name this robot? no
Does this robot have a specific size? no
Does this robot need to be a specific colour? no
ID: 1
You are producing robot #2
Do you want to name this robot? yes
What is its name? R2-D2
Does this robot have a specific size? yes
What is its height? 9
What is its width? 4
Does this robot need to be a specific colour? yes
What colour? azure
ID: 2
Name: R2-D2
Height: 9
Width: 4
Colour: azure
```

In exchange, she offers the Dynamic Medallion and all robots the factory makes before you fight the Uncoded One.

## Objectives

- Create a new `dynamic` variable, holding a reference to an `ExpandoObject`.
- Give the `dynamic` object an ID property whose type is `int` and assign each robot a new number.
- Ask the user if they want to name the robot, and if they do, collect it and store it in a `Name` property.
- Ask if they want to provide a size for the robot. If so, collect a width and height from the user and store those in `Width` and `Height` properties.
- Ask if they want to choose a colour for the robot. If so, store their choice in a `Colour` property.
- Display all existing properties for the robot to the console window using the following code:

```c#
foreach (KeyValuePair<string, object> property in (IDictionary<string, object>) robot)
{
    Console.WriteLine($"{property.Key}: {property.Value}");
}
```

- Loop repeatedly to allow the user to design and build multiple robots.
