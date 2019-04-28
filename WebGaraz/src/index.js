import ReactDOM from 'react-dom';
import AddDialogBox from '../Scripts/DialogBoxes/AddDialogBox.jsx';
require("babel-core/register");
require("babel-polyfill");

ReactDOM.render(
    <AddDialogBox />,
    document.getElementById('car-grid')
);
