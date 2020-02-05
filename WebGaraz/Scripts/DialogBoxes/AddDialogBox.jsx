import React, { Component } from 'react';
import { withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import MuiDialogTitle from '@material-ui/core/DialogTitle';
import MuiDialogContent from '@material-ui/core/DialogContent';
import MuiDialogActions from '@material-ui/core/DialogActions';
import IconButton from '@material-ui/core/IconButton';
import CloseIcon from '@material-ui/icons/Close';
import Typography from '@material-ui/core/Typography';
import PropTypes from 'prop-types';
import TextField from '@material-ui/core/TextField';
import MenuItem from '@material-ui/core/MenuItem';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import RepairDialogBox from '../DialogBoxes/RepairDialogBox.jsx';
import CarGrid from '../../src/App.js';
import CarMenu from '../Menu/menu.jsx';

import classNames from 'classnames';
import Select from 'react-select';

import NoSsr from '@material-ui/core/NoSsr';

import Paper from '@material-ui/core/Paper';
import Chip from '@material-ui/core/Chip';

import CancelIcon from '@material-ui/icons/Cancel';
import { emphasize } from '@material-ui/core/styles/colorManipulator';

const DialogTitle = withStyles(theme => ({
    root: {
        borderBottom: `1px solid ${theme.palette.divider}`,
        margin: 0,
        padding: theme.spacing.unit * 2,
    },
    closeButton: {
        position: 'absolute',
        right: theme.spacing.unit,
        top: theme.spacing.unit,
        color: theme.palette.grey[500],
    },
}))(props => {
    const { children, classes, onClose } = props;
    return (
        <MuiDialogTitle disableTypography className={classes.root}>
            <Typography variant="h6">{children}</Typography>
            {onClose ? (
                <IconButton aria-label="Close" className={classes.closeButton} onClick={onClose}>
                    <CloseIcon />
                </IconButton>
            ) : null}
        </MuiDialogTitle>
    );
});

const DialogContent = withStyles(theme => ({
    root: {
        margin: 0,
        padding: theme.spacing.unit * 2,
    },
}))(MuiDialogContent);

const DialogActions = withStyles(theme => ({
    root: {
        borderTop: `1px solid ${theme.palette.divider}`,
        margin: 0,
        padding: theme.spacing.unit,
    },
}))(MuiDialogActions);

function generateYearsArray(years) {
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    for (var year = 1990; year <= currentYear; year++) {
        years.push({ value: year.toString(), label: year.toString() });
    }

    return years;
}
let years = [];
generateYearsArray(years);



const styles = theme => ({
    root: {
        flexGrow: 1,
        height: '100%',
        width: 1080,
    },
    formControl: {
        margin: theme.spacing.unit,
        minWidth: 300,
    },
    input: {
        display: 'flex',
        padding: 0,
    },
    valueContainer: {
        display: 'flex',
        flexWrap: 'wrap',
        flex: 1,
        alignItems: 'center',
        overflow: 'hidden',
    },
    chip: {
        margin: `${theme.spacing.unit / 2}px ${theme.spacing.unit / 4}px`,
    },
    chipFocused: {
        backgroundColor: emphasize(
            theme.palette.type === 'light' ? theme.palette.grey[300] : theme.palette.grey[700],
            0.08,
        ),
    },
    noOptionsMessage: {
        padding: `${theme.spacing.unit}px ${theme.spacing.unit * 2}px`,
    },
    singleValue: {
        fontSize: 16,
    },
    placeholder: {
        position: 'absolute',
        left: 2,
        fontSize: 16,
    },
    paper: {
        position: 'absolute',
        zIndex: 1,
        marginTop: theme.spacing.unit,
        left: 0,
        right: 0,
    },
    divider: {
        height: theme.spacing.unit * 2,
    },
    container: {
        display: 'flex',
        flexWrap: 'wrap',
    },
    textField: {
        display: 'flex',
        width: 300,
        marginLeft: 0,
        marginRight: theme.spacing.unit,

    },
    dense: {
        marginTop: 16,
    },
    menu: {
        width: 200,
    },
});

function NoOptionsMessage(props) {
    return (
        <Typography
            color="textSecondary"
            className={props.selectProps.classes.noOptionsMessage}
            {...props.innerProps}
        >
            {props.children}
        </Typography>
    );
}

function inputComponent({ inputRef, ...props }) {
    return <div ref={inputRef} {...props} />;
}

function Control(props) {
    return (
        <TextField
            fullWidth
            InputProps={{
                inputComponent,
                inputProps: {
                    className: props.selectProps.classes.input,
                    inputRef: props.innerRef,
                    children: props.children,
                    ...props.innerProps,
                },
            }}
            {...props.selectProps.textFieldProps}
        />
    );
}

function Option(props) {
    return (
        <MenuItem
            buttonRef={props.innerRef}
            selected={props.isFocused}
            component="div"
            style={{
                fontWeight: props.isSelected ? 500 : 400,
            }}
            {...props.innerProps}
        >
            {props.children}
        </MenuItem>
    );
}

function Placeholder(props) {
    return (
        <Typography
            color="textSecondary"
            className={props.selectProps.classes.placeholder}
            {...props.innerProps}
        >
            {props.children}
        </Typography>
    );
}

function SingleValue(props) {
    return (
        <Typography className={props.selectProps.classes.singleValue} {...props.innerProps}>
            {props.children}
        </Typography>
    );
}

function ValueContainer(props) {
    return <div className={props.selectProps.classes.valueContainer}>{props.children}</div>;
}

function MultiValue(props) {
    return (
        <Chip
            tabIndex={-1}
            label={props.children}
            className={classNames(props.selectProps.classes.chip, {
                [props.selectProps.classes.chipFocused]: props.isFocused,
            })}
            onDelete={props.removeProps.onClick}
            deleteIcon={<CancelIcon {...props.removeProps} />}
        />
    );
}

function Menu(props) {
    return (
        <Paper square className={props.selectProps.classes.paper} {...props.innerProps}>
            {props.children}
        </Paper>
    );
}
const components = {
    Control,
    Menu,
    MultiValue,
    NoOptionsMessage,
    Option,
    Placeholder,
    SingleValue,
    ValueContainer,
};

class AddDialogBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: null,
            phone: '',
            phoneErrorText: '',
            brand: [],
            singleBrand: '',
            model: [],
            singleModel: '',
            isCarModelValid: false,
            isCarBrandValid: false,
            isCarEngineValid: false,
            engine: [],
            singleEngine: '',
            open: false,
            openDialog: false,
            updateCarGrid: false,
            name: 'Cat in the Hat',
            counter: '',
            counterErrorText: '',
            regNumber: '',
            regNumError: '',
            dueDateTechService: '',
            owner: '',
            owners: [],
            isOwnerValid: false,
            age: '',
            year: '',
            yearError: '',
            years: years,
            multiline: 'Controlled',
            single: 'dobri',
            multi: null,
            rows: [],
            row: null,
            isRowSelected: true,
            isEditDialogBox: false,
        };
    }

    componentDidMount() {
        fetch('/home/AllBrands')
            .then(response => response.json())
            .then(data => this.setState({
                brand: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        fetch('/home/allowners')
            .then(response => response.json())
            .then(data => this.setState({
                owners: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));


    }
    UpdateCarGrid = () => {
        return this;
    }
    NumberValidation = (value, name, length, errorMsg) => {
        var regex = /^\d+$/;
        if (!(value === null)) {
            if ((value.match(regex) && value.length < length) || value === "") {
                this.setState({
                    [name]: value,
                    [errorMsg]: ''
                });
            }
            else if (value.length === length) {

            }
            else {
                this.setState({
                    [errorMsg]: 'Tylko cyfry',
                })
            }
        }
        else {
            this.setState({
                [name]: '',
                [errorMsg]: '',
            })
        }
    }

    handleClickOpen = () => {
        this.setState({
            open: true,
            isEditDialogBox: false,
        });
    };
    handleAddRepair = () => {
        this.setState({
            openDialog: true,
        });
    }
    handleEditOpen = async () => {
        var brandRow = this.state.brand[this.state.brand.findIndex((singleModel) => singleModel.label === this.state.row.brand)];
        var modelRow = null;
        const fetchResult = await fetch('/home/allmodels?id=' + brandRow.value)
            .then(response => response.json())
            .then(data => this.setState({
                model: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        await fetchResult;
        modelRow = this.state.model[this.state.model.findIndex((singleModel) => singleModel.label === this.state.row.model)];
        debugger;
        fetch('/home/AllEnginesForCarByBrandIdAndModelId?brandId=' + this.state.brand[this.state.brand.findIndex((singleBrand) => brandRow == singleBrand)].value + "&modelId=" + modelRow.value)
            .then(response => response.json())
            .then(data => this.setState({
                engine: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        debugger;
        var engineRow = { value: this.state.row.engineId, label: this.state.row.engine };
        var counterRow = this.state.row.counter;
        var ownerRow = { value: this.state.row.owner.id, label: this.state.row.owner.name };
        var regNumberRow = this.state.row.regNum;
        var phoneRow = this.state.row.phone;
        var yearRow = this.state.row.year;
        var dueDateRow = this.state.row.dueDateTechService.substring(0, this.state.row.dueDateTechService.indexOf(" "));
        debugger;
        this.setState({
            singleBrand: brandRow,
            singleModel: modelRow,
            singleEngine: engineRow,
            counter: counterRow,
            phone: phoneRow,
            regNumber: regNumberRow,
            owner: ownerRow,
            year: yearRow,
            dueDateTechService: dueDateRow,
            open: true,
            isEditDialogBox: true,

        });

    };
    handleChangeDropDown = name => event => {
        this.setState({
            [name]: event.target.value,
            yearError: '',
        });
    };
    OnDateChange = name => event => {
        this.setState({
            [name]: event.target.value,
        });
        var due = this.state.dueDateTechService;
        debugger;
    };
    handleChange = name => value => {
        this.setState({
            [name]: value,
        });
    };
    handleChangeBrand = name => value => {
        fetch('/home/allmodels?id=' + value.value)
            .then(response => response.json())
            .then(data => this.setState({
                model: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        this.setState({
            [name]: value,
            isCarBrandValid: false,
        });

    };
    handleChangeModel = name => value => {
        fetch('/home/AllEnginesForCarByBrandIdAndModelId?brandId=' + this.state.brand[this.state.brand.findIndex((singleBrand) => this.state.singleBrand == singleBrand)].value + "&modelId=" + value.value)
            .then(response => response.json())
            .then(data => this.setState({
                engine: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        this.setState({
            [name]: value,
            isCarModelValid: false,
        });
    };
    handleChangeEngine = name => value => {
        this.setState({
            [name]: value,
            isCarEngineValid: false,
        });
    };
    handleChangeCounter = name => event => {
        this.NumberValidation(event.target.value, name, 8, 'counterErrorText');
    };
    handleChangeRegNumber = name => event => {
        this.setState({
            [name]: event.target.value.toUpperCase(),
            regNumError: '',
        });
    };
    handleChangeOwner = name => value => {
        this.setState({
            [name]: value,
            phoneErrorText: '',
        });
    };
    handleChangePhone = name => event => {
        this.NumberValidation(event.target.value, name, 15, 'phoneErrorText');
        this.setState({
            isOwnerValid: false,
        });
    };
    handleClose = () => {
        this.setState({ open: false });
    }
    SelectChange = (dialogButton) => {
        return this;
    }
    GetAddDialogBox = (dialogBox) => {
        return this;
    }
    handleSaveButton = async () => {

        if (this.state.isEditDialogBox == false) {
            var isCarModelInvalid = this.state.singleModel === '';
            var isCarBrandInvalid = this.state.singleBrand === '';
            var isCarEngineInvalid = this.state.singleEngine === '';
            var isPhoneInvalid = this.state.phone === '';
            var isOwnerNotSelected = this.state.owner === '' || this.state.owner === null;
            var isYearInvalid = this.state.year === '';
            var isRegNumInvalid = this.state.regNumber === '';

            if (isCarModelInvalid) {
                this.setState({ isCarModelValid: true });
            }
            if (isCarBrandInvalid) {
                this.setState({ isCarBrandValid: true });
            }
            if (isCarEngineInvalid) {
                this.setState({ isCarEngineValid: true });
            }
            if (isPhoneInvalid && isOwnerNotSelected) {
                this.setState({
                    phoneErrorText: 'Telefon lub właściciel wymagany',
                    isOwnerValid: true,
                });
            }
            if (isRegNumInvalid) {
                this.setState({
                    regNumError: 'Numer rejestracyjny wymagany',
                });
            }
            if (isYearInvalid) {
                this.setState({
                    yearError: 'Rok produkcji wymagany',
                });
            }
            if (!isCarModelInvalid && !isCarBrandInvalid && !isCarEngineInvalid && (!isOwnerNotSelected || !isPhoneInvalid)) {
                var ownerId = this.state.owners[this.state.owners.findIndex((owner) => this.state.owner.label == owner.label && this.state.owner.value == owner.value)].value;

                var carDTO =
                {
                    BrandId: this.state.brand[this.state.brand.findIndex((singleBrand) => this.state.singleBrand == singleBrand)].value,
                    ModelId: this.state.model[this.state.model.findIndex((singleModel) => this.state.singleModel == singleModel)].value,
                    Engine: this.state.engine[this.state.engine.findIndex((singleEngine) => this.state.singleEngine == singleEngine)].label,
                    Year: this.state.years[this.state.years.findIndex((year) => this.state.year == year.value)].value,
                    TechnicalCheck: (document.getElementById('date')).value,
                    PlateNumber: this.state.regNumber,
                    KilometerCounter: this.state.counter,
                    OwnerId: ownerId,
                    Phone: this.state.phone,
                };


                const postResult = await fetch('/home/addCar', {
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json'
                    },
                    method: 'POST',
                    body: JSON.stringify(carDTO)
                });
                await postResult;
                this.setState({
                    open: false,
                    updateCarGrid: true,
                });
            }
        }
        else {
            debugger;
            var ownerId = this.state.owners[this.state.owners.findIndex((owner) => this.state.owner.label == owner.label && this.state.owner.value == owner.value)].value;
            var enginee = this.state.engine[this.state.engine.findIndex((singleEngine) => this.state.singleEngine.label == singleEngine.label && this.state.singleEngine.value == singleEngine.value)].label;
            var carDTO =
            {
                Id: this.state.row.id,
                BrandId: this.state.brand[this.state.brand.findIndex((singleBrand) => this.state.singleBrand == singleBrand)].value,
                ModelId: this.state.model[this.state.model.findIndex((singleModel) => this.state.singleModel == singleModel)].value,
                Engine: this.state.engine[this.state.engine.findIndex((singleEngine) => this.state.singleEngine.label == singleEngine.label && this.state.singleEngine.value == singleEngine.value)].label,
                Year: this.state.years[this.state.years.findIndex((year) => this.state.year == year.value)].value,
                TechnicalCheck: (document.getElementById('date')).value,
                PlateNumber: this.state.regNumber,
                KilometerCounter: this.state.counter,
                OwnerId: ownerId,
                Phone: this.state.phone,

            };
            const putResult = await fetch('home/updateCar?id=' + this.state.row.id, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: 'PUT',
                body: JSON.stringify(carDTO)

            });
            await putResult;
            this.setState({
                open: false,
                updateCarGrid: true,
            });
        }
    };

    render() {
        const { classes, theme } = this.props;

        const selectStyles = {
            input: base => ({
                ...base,
                color: theme.palette.text.primary,
                '& input': {
                    font: 'inherit',
                },
            }),
        };
        return (
            <div>
                <CarMenu />
                <CarGrid update={this.UpdateCarGrid()} selectChange={this.SelectChange(this)} />
                <Button variant="outlined" color="secondary" onClick={this.handleClickOpen}>
                    Dodaj Nowe Auto
                </Button>
                <Button variant="outlined" color="secondary" onClick={this.handleEditOpen} disabled={this.state.isRowSelected}>
                    Edytuj Auto
                </Button>
                <Button variant="outlined" color="secondary" onClick={this.handleAddRepair} disabled={this.state.isRowSelected}>
                    Dodaj Naprawe
                </Button>
                <Dialog
                    onClose={this.handleClose}
                    aria-labelledby="customized-dialog-title"
                    open={this.state.open}
                >
                    <DialogTitle id="customized-dialog-title" onClose={this.handleClose}>
                        Dodaj Auto
                    </DialogTitle>
                    <DialogContent>
                        <form id="addCarForm" className={classes.container} noValidate autoComplete="off">

                            <div className={classes.root}>
                                <NoSsr>
                                    <FormControl className={classes.formControl} error={this.state.isCarBrandValid}>
                                        <Select
                                            classes={classes}
                                            styles={selectStyles}
                                            options={this.state.brand}
                                            components={components}
                                            value={this.state.singleBrand}
                                            onChange={this.handleChangeBrand('singleBrand')}
                                            placeholder="Wybierz Marke"
                                            isClearable
                                        />
                                        {this.state.isCarBrandValid && <FormHelperText> This is required!</FormHelperText>}
                                    </FormControl>
                                    <div className={classes.divider} />
                                    <FormControl className={classes.formControl} error={this.state.isCarModelValid}>
                                        <Select
                                            classes={classes}
                                            styles={selectStyles}
                                            options={this.state.model}
                                            components={components}
                                            value={this.state.singleModel}
                                            onChange={this.handleChangeModel('singleModel')}
                                            placeholder="Wybierz Model"
                                            isClearable
                                        />
                                        {this.state.isCarModelValid && <FormHelperText>This is required!</FormHelperText>}
                                    </FormControl>
                                    <div className={classes.divider} />
                                    <FormControl className={classes.formControl} error={this.state.isCarEngineValid}>
                                        <Select
                                            classes={classes}
                                            styles={selectStyles}
                                            options={this.state.engine}
                                            components={components}
                                            value={this.state.singleEngine}
                                            onChange={this.handleChangeEngine('singleEngine')}
                                            placeholder="Wybierz Silnik"
                                            isClearable
                                        />
                                        {this.state.isCarEngineValid && <FormHelperText>This is required!</FormHelperText>}
                                    </FormControl>
                                    <TextField
                                        id="outlined-select-currency"
                                        select
                                        error={this.state.yearError.length !== 0 ? true : false}
                                        label="Wybierz rok produkcji"
                                        className={classes.textField}
                                        value={this.state.year}
                                        onChange={this.handleChangeDropDown('year')}
                                        SelectProps={{
                                            MenuProps: {
                                                className: classes.menu,
                                            },
                                        }}
                                        helperText={this.state.yearError}
                                        margin="normal"
                                        variant="outlined"
                                    >
                                        {years.map(option => (
                                            <MenuItem key={option.value} value={option.value}>
                                                {option.label}
                                            </MenuItem>
                                        ))}
                                    </TextField>

                                    <TextField
                                        id="outlined-name"
                                        label="Stan Licznika"
                                        error={this.state.counterErrorText.length !== 0 ? true : false}
                                        className={classes.textField}
                                        helperText={this.state.counterErrorText}
                                        value={this.state.counter}
                                        onChange={this.handleChangeCounter('counter')}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                    <TextField
                                        id="outlined-name"
                                        label="Numer Rejestracyjny"
                                        error={this.state.regNumError.length !== 0 ? true : false}
                                        helperText={this.state.regNumError}
                                        className={classes.textField}
                                        value={this.state.regNumber}
                                        onChange={this.handleChangeRegNumber('regNumber')}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                    <TextField
                                        id="date"
                                        label="Badanie techniczne"
                                        type="date"
                                        value={this.state.dueDateTechService}
                                        className={classes.textField}
                                        onChange={this.OnDateChange('dueDateTechService')}
                                        InputLabelProps={{
                                            shrink: true,
                                        }}

                                    />
                                    <FormControl className={classes.formControl} error={this.state.isOwnerValid}>

                                        <Select
                                            classes={classes}
                                            styles={selectStyles}
                                            options={this.state.owners}
                                            components={components}
                                            value={this.state.owner}
                                            onChange={this.handleChangeOwner('owner')}
                                            placeholder="Wybierz właściciela"
                                            isClearable
                                        />
                                        {this.state.isOwnerValid && <FormHelperText>{this.state.phoneErrorText}</FormHelperText>}
                                    </FormControl>
                                    <TextField
                                        id="outlined-name"
                                        label="Numer telefonu"
                                        error={this.state.phoneErrorText.length !== 0 ? true : false}
                                        helperText={this.state.phoneErrorText}
                                        className={classes.textField}
                                        value={this.state.phone}
                                        onChange={this.handleChangePhone('phone')}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                </NoSsr>
                            </div>
                        </form>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleSaveButton} color="primary">
                            Dodaj Auto
                        </Button>
                    </DialogActions>
                </Dialog>
                <RepairDialogBox GetDialogBox={this.GetAddDialogBox(this)} />
            </div>

        );
    }
}
AddDialogBox.propTypes = {
    classes: PropTypes.object.isRequired,
    theme: PropTypes.object.isRequired,
};
export default withStyles(styles, { withTheme: true })(AddDialogBox);