import {MDCTextField} from '@material/textfield';
import {MDCRipple} from '@material/ripple';

const loginUsernameTextField = new MDCTextField(document.querySelector('#login-username-textfield'));
const loginPasswordTextField = new MDCTextField(document.querySelector('#login-password-textfield'));
const loginButton = new MDCRipple(document.querySelector('#login-button'));