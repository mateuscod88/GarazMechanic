import React, { Component } from 'react';

import AddDialogBox from '../DialogBoxes/AddDialogBox.jsx';
var style = {
    width: 1180,
    margin: '0 auto',
};
class CarContainer extends Component{
    
    render(){
        return (
            <div style={style}>
                
                <AddDialogBox />
                </div>
                );
    }
}
export default CarContainer;