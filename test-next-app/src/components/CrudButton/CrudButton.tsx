import React, { FC } from 'react';
import { CrudButtonWrapper, Button } from './CrudButton.styled';

interface CrudButton {

}

type CrudButtonProps = {
	label: string,
}

const CrudButton: FC<CrudButtonProps> = ({label}) => (
	<CrudButtonWrapper>
		<Button className="btn" type="submit" onClick={() => addFunction(label)}>{label}</Button>
	</CrudButtonWrapper>
);

function addFunction (e: string) {
	console.log(e, " Function...")
}

export default CrudButton;
