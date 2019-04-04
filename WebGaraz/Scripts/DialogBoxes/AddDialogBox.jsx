﻿import React, { Component } from 'react';
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


const currencies = [
    {
        value: 'USD',
        label: '$',
    },
    {
        value: 'EUR',
        label: '€',
    },
    {
        value: 'BTC',
        label: '฿',
    },
    {
        value: 'JPY',
        label: '¥',
    },
];
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

const suggestions = [
    { label: 'Afghanistan' },
    { label: 'Aland Islands' },
    { label: 'Albania' },
    { label: 'Algeria' },
    { label: 'American Samoa' },
    { label: 'Andorra' },
    { label: 'Angola' },
    { label: 'Anguilla' },
    { label: 'Antarctica' },
    { label: 'Antigua and Barbuda' },
    { label: 'Argentina' },
    { label: 'Armenia' },
    { label: 'Aruba' },
    { label: 'Australia' },
    { label: 'Austria' },
    { label: 'Azerbaijan' },
    { label: 'Bahamas' },
    { label: 'Bahrain' },
    { label: 'Bangladesh' },
    { label: 'Barbados' },
    { label: 'Belarus' },
    { label: 'Belgium' },
    { label: 'Belize' },
    { label: 'Benin' },
    { label: 'Bermuda' },
    { label: 'Bhutan' },
    { label: 'Bolivia, Plurinational State of' },
    { label: 'Bonaire, Sint Eustatius and Saba' },
    { label: 'Bosnia and Herzegovina' },
    { label: 'Botswana' },
    { label: 'Bouvet Island' },
    { label: 'Brazil' },
    { label: 'British Indian Ocean Territory' },
    { label: 'Brunei Darussalam' },
].map(suggestion => ({
    value: suggestion.label,
    label: suggestion.label,
}));

const styles = theme => ({
    root: {
        flexGrow: 1,
        height: 250,
        width: 1080,
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
        display: 'table',
        marginLeft: theme.spacing.unit,
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
            brand: [],
            singleBrand:'',
            model: [],
            singleModel: '',
            engine: [],
            singleEngine:'',
            open: false,
            name: 'Cat in the Hat',
            counter: '',
            regNumber: '',
            owner: '',
            owners: [],
            age: '',
            year: '',
            years: years,
            multiline: 'Controlled',
            currency: 'EUR',
            single: 'dobri',
            multi: null,
        };
    }

    componentDidMount() {
        fetch('/home/allcars')
            .then(response => response.json())
            .then(data => this.setState({
                brand:(data.map(suggestion => ({
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
    

    handleClickOpen = () => {
        this.setState({
            open: true,
        });
    };
    handleChangeDropDown = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };
    handleChange = name => value => {
        this.setState({
            [name]: value,
        });
    };
    handleChangeBrand = name => value => {
        fetch('/home/allmodels?id='+ value.value)
            .then(response => response.json())
            .then(data => this.setState({
                model: (data.map(suggestion => ({
                    value: suggestion.ID,
                    label: suggestion.Name,
                }))),
            }));
        this.setState({
            [name]: value,
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
        });
    };
    handleChangeEngine = name => value => {
        this.setState({
            [name]: value,
        });
    };
    handleChangeCounter = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };
    handleChangeRegNumber = name => event => {
        this.setState({
            [name]: event.target.value,
        });
    };
    handleChangeOwner = name => value => {
        this.setState({
            [name]: value,
        });
    };
    handleClose = () => {
        console.log(this.state.model);
        console.log(this.state.years.findIndex((year) => this.state.year == year.toString()));
        console.log(this.state.years[1]);

        console.log(this.state.years[1].value);

        var body = '{"brandId":' + this.state.brand[this.state.brand.findIndex((singleBrand) => this.state.singleBrand == singleBrand)].value + ','
            + '"modelId":' + this.state.model[this.state.model.findIndex((singleModel) => this.state.singleModel == singleModel)].value + ','
            + '"engineId":' + this.state.engine[this.state.engine.findIndex((singleEngine) => this.state.singleEngine == singleEngine)].value + ','
            + '"year":' + this.state.years[this.state.years.findIndex((year) => this.state.year == year.toString())].value + ','
            + '"techcheck":' + (document.getElementById('date')).value
            + '}';


        console.log(body);
        var form = new FormData(document.getElementById('addCarForm'));
        fetch('/home/addCar',{
            method: 'POST',
            body: body
        });
        console.log(form);
        this.setState({ open: false });
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
                <Button variant="outlined" color="secondary" onClick={this.handleClickOpen}>
                    Open dialog
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
                                    <div className={classes.divider} />
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
                                    <div className={classes.divider} />
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
                                    <TextField
                                        id="outlined-select-currency"
                                        select
                                        label="Select"
                                        className={classes.textField}
                                        value={this.state.year}
                                        onChange={this.handleChangeDropDown('year')}
                                        SelectProps={{
                                            MenuProps: {
                                                className: classes.menu,
                                            },
                                        }}
                                        helperText="Wybierz rok produkcji"
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
                                        className={classes.textField}
                                        value={this.state.counter}
                                        onChange={this.handleChangeCounter('counter')}
                                        margin="normal"
                                        variant="outlined"
                                    />
                                    <TextField
                                        id="outlined-name"
                                        label="Numer Rejestracyjny"
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
                                        className={classes.textField}
                                        InputLabelProps={{
                                            shrink: true,
                                        }}

                                    />
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
                                </NoSsr>
                            </div>
                        </form>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleClose} color="primary">
                            Save changes
            </Button>
                    </DialogActions>
                </Dialog>
            </div>
        );
    }
}
AddDialogBox.propTypes = {
    classes: PropTypes.object.isRequired,
    theme: PropTypes.object.isRequired,
};
export default withStyles(styles, { withTheme: true })(AddDialogBox);