import { Container } from 'react-bootstrap';
import WeatherForecast from './pages/WeatherForecast';
import Menu from './components/Menu';
import { Route, Routes } from 'react-router-dom';

const GetRoutes = () => [
    {
        index: true,
        element: <h2>Hello, World!</h2>
    },
    {
        path: "/weather-forecast",
        element: <WeatherForecast />
    },
    {
        path: "/test",
        element: <h2>Test!</h2>
    },
];

export default function App() {
    return (
        <div>
            <Menu />

            <Container>
                <Routes>
                    {
                        GetRoutes().map((route, index) => {
                            const { element, ...rest } = route;
                            return <Route key={index} {...rest} element={element} />;
                        })
                    }
                </Routes>
            </Container>
        </div>
    );
}