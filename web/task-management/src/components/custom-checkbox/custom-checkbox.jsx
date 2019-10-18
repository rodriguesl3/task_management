import React from 'react';

import './custom-checkbox.css'



const CustomCheckBox = (props) => {
    const { isChecked, description, keyCode, changeStatus } = props;
    const updateStatus = (elm) => {
        changeStatus(keyCode, elm.target.checked);
    }


    return (
        <div>
            <input id={`checkbox-${keyCode}`}
                class="checkbox-custom" name={`checkbox-${keyCode}`}
                type="checkbox"
                onChange={updateStatus}
                checked={isChecked == 1 ? true : false} />
            <label for={`checkbox-${keyCode}`} class="checkbox-custom-label">{description}</label>
        </div>

    );
}

export default CustomCheckBox;