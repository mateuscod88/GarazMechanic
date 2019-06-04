import React from 'react';
import Button from '@material-ui/core/Button';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';

class CarMenu extends React.Component {
    state = {
        anchorEl: null,
    };

    handleClick = event => {
        this.setState({ anchorEl: event.currentTarget });
    };

    handleClose = () => {
        debugger;
        
        this.setState({ anchorEl: null });
    };
    handleRouteCar = () => {
        if (typeof window !== 'undefined') {
            window.location.href = '/';
        }
        this.setState({ anchorEl: null });
    };
    handleRouteRepairs = () => {
        if (typeof window !== 'undefined') {
            window.location.href = '/repairs';
        }
        this.setState({ anchorEl: null });
    };
    render() {
        const { anchorEl } = this.state;

        return (
            <div>
                <Button
                    aria-owns={anchorEl ? 'simple-menu' : undefined}
                    aria-haspopup="true"
                    onClick={this.handleClick}
                >
                    Menu
                </Button>
                <Menu
                    id="simple-menu"
                    anchorEl={anchorEl}
                    open={Boolean(anchorEl)}
                    onClose={this.handleClose}
                >
                    <MenuItem onClick={this.handleRouteCar}>Auta</MenuItem>
                    <MenuItem onClick={this.handleRouteRepairs}>Naprawy</MenuItem>
                </Menu>
            </div>
        );
    }
}

export default CarMenu;