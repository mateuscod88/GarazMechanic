import ReactDOM from 'react-dom';
import ContainerRepair from '../Scripts/Repair/ContainerRepair.jsx';
require("babel-core/register");
require("babel-polyfill");

ReactDOM.render(
    <ContainerRepair />,
    document.getElementById('car-grid')
);
