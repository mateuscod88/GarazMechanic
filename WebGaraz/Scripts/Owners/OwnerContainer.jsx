import React, { Component } from 'react';
import RepairService from '../Repair/Service/RepairService.jsx';
import RepairGrid from '../Repair/RepairGrid.jsx';
import RepairDetailsDialogBox from '../Repair/RepairDetailsDialogBox.jsx';
import CarMenu from '../Menu/menu.jsx';

import Button from '@material-ui/core/Button';
class ContainerOwners extends Component {
    constructor(props) {
        super(props);
        this._ownerService = new RepairService();

        this.state =
        {
            open: this._ownerService.SetRepairDetailsDialogBox(false),
            isRowSelected : false,
        };

    }
    handleClickOpen = () => {
        //
        this.setState({
            open: true,
        });
    }
    handleCloseDialogBox = () => {
        this.setState({
            open:false,
        });
    }
    handleRowSelection = (isRowSelected) => {
        this.setState({
            isRowSelected: isRowSelected,
        });
    }
    render() {
        return (
            <div>
                <CarMenu />
                <OwnerGrid service={this._ownerService} onRowSelected={this.handleRowSelection} />
                <OwnerDetailsDialogBox service={this._ownerService} open={this.state.open} onClose={this.handleCloseDialogBox} />
                <Button variant="outlined" color="secondary" onClick={this.handleClickOpen}  disabled={!this.state.isRowSelected}>
                    Edytuj Wlasciciela
                </Button>
            </div>
        )
    }
}
export default ContainerOwners;