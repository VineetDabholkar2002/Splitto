import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import WeatherForecast from "./components/WeatherForecast";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<h1>Welcome to the Weather App</h1>} />
                <Route path="/weather" element={<WeatherForecast />} />
            </Routes>
        </Router>
    );
}

export default App;
