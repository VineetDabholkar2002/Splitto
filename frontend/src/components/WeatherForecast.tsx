import React, { useEffect, useState } from "react";
import axios from "axios";

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

const WeatherForecast = () => {
    const [forecasts, setForecasts] = useState<WeatherForecast[]>([]);

    useEffect(() => {
        const fetchWeatherData = async () => {
            try {
                const response = await axios.get("/api/WeatherForecast");
                console.log(response.data)
                setForecasts(response.data);
            } catch (error) {
                console.error("Error fetching weather data:", error);
            }
        };

        fetchWeatherData();
    }, []);

    return (
        <div>
            <h1>Weather Forecast</h1>
            <ul>
                {forecasts.map((forecast, index) => (
                    <li key={index}>
                        <strong>Date:</strong> {new Date(forecast.date).toDateString()} | 
                        <strong> Temp (C):</strong> {forecast.temperatureC} | 
                        <strong> Temp (F):</strong> {forecast.temperatureF} | 
                        <strong> Summary:</strong> {forecast.summary}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default WeatherForecast;
