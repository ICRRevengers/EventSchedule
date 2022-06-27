import { Link } from 'react-router-dom';
const Button = ({
    to,
    href,
    disabled = false,
    className,
    children,
    ...otherProps
}) => {
    let Comp = 'button'; // this is default value JSX
    let props = {
        ...otherProps,
    };

    if (disabled) {
        Object.keys(props).forEach((key) => {
            if (key.startsWith('on') || typeof props[key] === 'function') {
                delete props[key];
            }
        });
    }

    if (to) {
        props.to = to; //add a element into props
        Comp = Link; // change to Link to match path
    } else if (href) {
        props.href = href;
        Comp = 'a'; //change to a tag
    }

    return (
        <Comp
            className={
                'flex items-center justify-center bg-[#000070] text-[#fff] px-[15px] py-[10px] rounded-[5px] transition duration-200 hover:bg-[#000050] min-w-[100px] min-h-[35px] h-fit select-none ' +
                className
            }
            {...props}
        >
            <span>{children}</span>
        </Comp>
    );
};

export default Button;
