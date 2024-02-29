import userContext from "../context/userContext"
import Base from "../components/Base"

const Services = () => {
    return (
        <userContext.Consumer>
            {
                (object) => (

                    <Base>
                        <h1>Welcome {object.user.login && object.user.data.name}</h1>
                    </Base>
                )
            }
        </userContext.Consumer>
    )
}

export default Services