using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlightinAir
{
    public DateTime departure;
    public DateTime arrival;
    public string originePort;
    public string destinationPort;
    public string flightNumber;
}
public class InAirData
{
    public string id;
    public string type;
    public string date;
    public string context;
    public string valid;
    public string sameAs;
    public string airline;
    public string Operator;
    public string aircraftType;
    public string[] flightNumber;
    public string flightStatus;
    public string departureAirport;
    public string destinationAirport;
    public string actualDepartureTime;
    public string scheduledDepartureTime;
}