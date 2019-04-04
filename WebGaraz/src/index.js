import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import GarazMenu from './menu.jsx';
import CarGrid from './App.js';
import AddDialogBox from '../Scripts/DialogBoxes/AddDialogBox.jsx';
import AddForm from '../Scripts/DialogBoxes/AddForm.jsx';
import IntegrationReactSelect from '../Scripts/DialogBoxes/Controls/dropdown.jsx';

ReactDOM.render(
    <GarazMenu/>,
    document.getElementById('content-menu')
    );
ReactDOM.render(
    <CarGrid/>,
    document.getElementById('car-grid')
);
ReactDOM.render(
    <AddDialogBox />,
    document.getElementById('add-dialog-btn')
);
ReactDOM.render(
    <AddForm/>,
    document.getElementById('add-form')
);
//ReactDOM.render(
//    <IntegrationReactSelect />,
//    document.getElementById('demo')
//);