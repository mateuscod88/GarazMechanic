import React, { Component } from 'react';
import RepairService from '../Repair/Service/RepairService.jsx';
import RepairGrid from '../Repair/RepairGrid.jsx';

class ContainerRepair extends Component {
    constructor(props) {
        super(props);
        this._repairService = new RepairService();
        
    }
    render() {
        return (
            <div>
                <RepairGrid service={this._repairService} />
            </div>
            )
    }
}
export default ContainerRepair;